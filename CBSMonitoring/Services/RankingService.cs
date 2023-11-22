using AutoMapper;
using CBSMonitoring.Constants;
using CBSMonitoring.DTOs;
using CBSMonitoring.Model;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Net;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public class RankingService : IRankingService
    {
        private readonly IGenericRepository _rankingRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _applicationUserService;
        private record Org(int OrganizationId, string Name);
        private record QbWithSection(string QuestionBlockNumber, IEnumerable<string> Sections);
        private record QbWithPoint(string QuestionBlockNumber, int MaxScore);
        private record MRecordsSectionNum(int OrganizationId, string SectionNumber);
        private record EvaluationRecord(int OrganizationId, string BlockNumber, double Score);
        private record Score(double Point, int OrganizationId);
        public RankingService(IGenericRepository rankingRepository, IMapper mapper, 
                                IApplicationUserService applicationUserService)
        {
            _rankingRepository = rankingRepository;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
        }
        public async Task<Result<string>> Evaluate(EvaluationRequest evaluationRequest)
        {
            try
            {
                if (ValidateScore(evaluationRequest.BlockNumber, evaluationRequest.Score).Result)
                {
                    var evaluation = _mapper.Map<Evaluation>(evaluationRequest);
                    evaluation.EvaluatedTime = DateTime.Now;

                    var existingEvaluation = await _rankingRepository.GetFirstByParameterAsync<Evaluation>
                        (e => e.BlockNumber == evaluation.BlockNumber 
                        && e.Year == evaluation.Year 
                        && e.QuarterIndex == evaluation.QuarterIndex
                        && e.OrganizationId == evaluation.OrganizationId);

                    var isEvaluatedAlready = existingEvaluation == null ? false : true;

                    if (isEvaluatedAlready)
                    {
                        _mapper.Map(evaluation, existingEvaluation);
                        await _rankingRepository.UpdateAsync(existingEvaluation!);
                    }

                    else
                        await _rankingRepository.AddAsync(evaluation);
                }

                else
                    return await Result<string>.FailAsync($"Assigned Score is higher than maximum point!");

            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }
        public async Task<Result<ScoreResponse>> GetEvaluationOfIndicator(ScoreRequestByIndicator scoreRequest)
        {
            // Validate request
            if (!ValidateScoreRequest(scoreRequest, 1).Result)
            {
                return await Result<ScoreResponse>.FailAsync($"Indicator => not found!");
            }

            // Get current user's organization id or check if user is authorized for this organization info
            var orgIdResult = await GetOrganizationId(scoreRequest.OrganizationId);

            if (!orgIdResult.Succeeded)
            {
                return await Result<ScoreResponse>.FailAsync(
                    orgIdResult.Code, orgIdResult.Messages);
            }

            scoreRequest.OrganizationId = orgIdResult.Data;

            var evaluation = await _rankingRepository.GetFirstByParameterAsync<Evaluation>(
                e => e.BlockNumber == scoreRequest.BlockNumber
                    && e.Year == scoreRequest.Period.Year
                    && e.QuarterIndex == scoreRequest.Period.Quarter
                    && e.OrganizationId == scoreRequest.OrganizationId);

            if (evaluation == null)
                return await Result<ScoreResponse>.FailAsync($"Evaluation with parameters => {scoreRequest} not found!");

            try
            {
                return await Result<ScoreResponse>.SuccessAsync(_mapper.Map<ScoreResponse>(evaluation));
            }
            catch (Exception ex)
            {
                return await Result<ScoreResponse>.FailAsync(ex.Message);
            }

        }
        public async Task<Result<IEnumerable<ScoreResponse>>> GetRankingsOfOrganizationsByIndicator(ScoreRequestByIndicator scoreRequest)
        {
            // Validate request
            if (!ValidateScoreRequest(scoreRequest, 1).Result)
            {
                return await Result<IEnumerable<ScoreResponse>>.FailAsync($"Indicator => not found!");
            }

            // Get all the rankings for the given criteria
            var rankings = await _rankingRepository.SelectAllAsync<Evaluation, ScoreResponse>(
                e => new ScoreResponse(e.Organization.FullName, e.Score, e.EvaluatedTime, e.Comment, false, null),
                e => e.BlockNumber == scoreRequest.BlockNumber
                    && e.Year == scoreRequest.Period.Year
                    && e.QuarterIndex == scoreRequest.Period.Quarter,
                query => query.Include(e => e.Organization));

            // Convert rankings to a dictionary for faster lookup
            var rankingLookup = rankings.ToDictionary(r => r.Discriminator, r => r);

            // Get all organizations
            var orgs = await _rankingRepository.SelectAllAsync<Organization, Org>(
                e => new Org(e.OrganizationId, e.FullName));

            //Get Quesiton Block Max Point
            int? maxPoint = (await _rankingRepository.GetFirstByParameterAsync<QuestionBlock>(e => e.BlockNumber == scoreRequest.BlockNumber))?.MaxScore;

            // Build the response list
            var response = orgs.Select(org =>
                rankingLookup.TryGetValue(org.Name, out var ranking)
                    ? new ScoreResponse(ranking.Discriminator, ranking.Score, ranking.EvaluatedTime, ranking.Comment, true, maxPoint)
                    : new ScoreResponse(org.Name, null, null, null, false, maxPoint)
            ).OrderByDescending(e => e.Score).ToList();

            return await Result<IEnumerable<ScoreResponse>>.SuccessAsync(response);
        }
        public async Task<Result<IEnumerable<RankingResponse>>> GetRankingsOfOrganizations(Period? period)
        {
            //var stopwatch = new Stopwatch();
            //stopwatch.Start();

            period ??= new Period();

            // Fetch all the rankings for the given period
            var rankings = await _rankingRepository.SelectAllAsync<Evaluation, EvaluationRecord>(
                e => new(e.OrganizationId, e.BlockNumber, e.Score),
                e => e.Year == period.Year
                    && e.QuarterIndex == period.Quarter,
                query => query.Include(e => e.Organization));

            // Group them by OrganizationId
            var orgRankingsGrouped = rankings
                .GroupBy(r => r.OrganizationId)
                .ToDictionary(g => g.Key, g => (g.Sum(e => e.Score), g.Count()));

            // Fetch question blocks
            var questionBlocks = await _rankingRepository.SelectAllAsync<QuestionBlock, QbWithSection>(
                e => new QbWithSection(e.BlockNumber, e.FormSections.Select(s => s.SectionNumber)),
                e => e.IsActive,
                query => query.Include(q => q.FormSections)
            );

            int NumberOfQbs = questionBlocks.Count();

            // Fetch all organizations with default null score
            var organizations = await _rankingRepository.SelectAllAsync<Organization, RankingResponse>(
                o => new (o.OrganizationId, o.FullName, null, NumberOfQbs, period), o => o.Status);

            // Fetch monitoring records for the given period
            var recordSectionNums = await _rankingRepository.SelectAllAsync<OrgMonitoring, MRecordsSectionNum>(
                    o => new MRecordsSectionNum(o.OrganizationId, o.SectionNumber),
                    o => o.Year == period.Year && o.QuarterIndex == period.Quarter
                );
            // Group them by OrganizationId
            var recordsSectionNumsGrouped = recordSectionNums
                .GroupBy(m => m.OrganizationId)
                .ToDictionary(g => g.Key, g => g.Select(m => m.SectionNumber));

            foreach (var org in organizations)
            {
                // Assign scores from the grouped rankings.
                org.Score = orgRankingsGrouped.TryGetValue(org.OrganizationId, out var ranking) ? ranking.Item1 : null;
                org.NumberOfEvaluatedQbs = ranking.Item2;

                double filledBlocksPortion = 0;
                foreach (var qb in questionBlocks)
                {
                    // Use the pre-fetched monitoring records for calculations.
                    int filledSectionCount = qb.Sections.Count(sectionNumber =>
                        recordsSectionNumsGrouped.TryGetValue(org.OrganizationId, out var sections)
                        && sections.Any(s => s == sectionNumber)
                    );

                    filledBlocksPortion += (double)filledSectionCount / qb.Sections.Count();
                }

                org.Completion = (double)filledBlocksPortion / questionBlocks.Count() * 100;
            }

            var response = organizations.OrderByDescending(e => e.Score).ToList();

            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

            return await Result<IEnumerable<RankingResponse>>.SuccessAsync(response);
        }
        public async Task<Result<IEnumerable<ScoreResponse>>> GetScoresOfOrganization(ScoreRequest scoreRequest)
        {
            // Validate request
            if (!ValidateScoreRequest(scoreRequest,2).Result)
            {
                return await Result<IEnumerable<ScoreResponse>>.FailAsync($"Organization => not found!");
            }

            // Get current user's organization id or check if user is authorized for this organization info
            var orgIdResult = await GetOrganizationId(scoreRequest.OrganizationId);

            if (!orgIdResult.Succeeded)
            {
                return await Result<IEnumerable<ScoreResponse>>.FailAsync(
                    orgIdResult.Code, orgIdResult.Messages);
            }

            scoreRequest.OrganizationId = orgIdResult.Data;

            // Get all the evaluations of the organization for the given criteria
            var evaluations = await _rankingRepository.SelectAllAsync<Evaluation, ScoreResponse>(
                e => new ScoreResponse(e.BlockNumber, e.Score, e.EvaluatedTime, e.Comment, false, null),
                e => e.OrganizationId == scoreRequest.OrganizationId
                    && e.Year == scoreRequest.Period.Year
                    && e.QuarterIndex == scoreRequest.Period.Quarter);

            // Convert evaluations to dictionary for faster lookup
            var evaluationLookup = evaluations.ToDictionary(e => e.Discriminator, e => e);

            // Get all question blocks
            var indicators = await _rankingRepository.SelectAllAsync<QuestionBlock, QbWithPoint>(e => new QbWithPoint(e.BlockNumber, e.MaxScore));

            // Build the response list
            var response = indicators.Select(i =>
                evaluationLookup
                .TryGetValue(i.QuestionBlockNumber, out var evaluation)
                    ? new ScoreResponse(
                        evaluation.Discriminator, 
                        evaluation.Score, 
                        evaluation.EvaluatedTime, 
                        evaluation.Comment, 
                        true, 
                        i.MaxScore)
                    : new ScoreResponse(
                        i.QuestionBlockNumber, 
                        null, 
                        null, 
                        null, 
                        false, 
                        i.MaxScore)
            ).OrderByDescending(s => s.Score)
            .ToList();

            return await Result<IEnumerable<ScoreResponse>>.SuccessAsync(response);
        }
        public async Task<Result<string>> ReEvaluate(ReEvaluationRequest reEvaluationRequest)
        {
            var evaluation = await _rankingRepository.GetByIdAsync<Evaluation>(reEvaluationRequest.EvaluationId);
            if (evaluation == null)
                return await Result<string>.FailAsync($"Evaluation with id={reEvaluationRequest.EvaluationId} not found");
            try
            {
                await _rankingRepository.UpdateAsync(_mapper.Map(reEvaluationRequest, evaluation));
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }
        public async Task<Result<string>> RemoveEvaluation(int id)
        {
            var evaluation = await _rankingRepository.GetByIdAsync<Evaluation>(id);

            if (evaluation == null)
                return await Result<string>.FailAsync($"Evaluation with id={id} not found!");

            try
            {
                await _rankingRepository.DeleteAsync(evaluation);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }
        public async Task<Result<ScoreStatsReponse>> GetStatisticsForPeriod(int periodOfQuarters, int organizationId = 0) // for the last x quarters
        {
            var organizationIdResult = await GetOrganizationId(organizationId);

            if (!organizationIdResult.Succeeded)
            {
                return await Result<ScoreStatsReponse>.FailAsync(
                    organizationIdResult.Code, organizationIdResult.Messages);
            }

            organizationId = organizationIdResult.Data;

            var organizationName = (await _rankingRepository.GetFirstByParameterAsync<Organization>(
                e => e.OrganizationId == organizationId))?
                .ShortName;

            // get maximum possible score
            var maxScore = (await _rankingRepository.SelectAllAsync<QuestionBlock, Score>(
                        e => new(e.MaxScore, 0)))
                        .Sum(s => s.Point);

            // get scores of organization for the given period
            var scoreForPeriods = await GetScoresForPeriod(periodOfQuarters, maxScore);

            ScoreStatsReponse response = new()
            {
                 OrganizationId = organizationId,
                 OrganizationName = organizationName,
                 Scores = scoreForPeriods
            };

            return await Result<ScoreStatsReponse>.SuccessAsync(response);
            
        }             
        public async Task<Result<IEnumerable<ScoreForPeriod>>> GetAllInOneStatiscticsForPeriod(int periodOfQuarters)
        {
            // get the count of active organizations
            var orgsCount = (await _rankingRepository.GetAllAsync<Organization>(o => o.Status)).Count();
            // get maximum possible score
            var maxScore = (await _rankingRepository.SelectAllAsync<QuestionBlock, Score>(
                        e => new(e.MaxScore, 0)))
                        .Sum(s => s.Point) * orgsCount;

            var statistics = await GetScoresForPeriod(periodOfQuarters, maxScore);

            return await Result<IEnumerable<ScoreForPeriod>>.SuccessAsync(statistics);
        }
        public async Task<Result<IEnumerable<StatsForCertainCriteriaResponse>>> GetStatsForCriteria(double percentageCriteria, int periodOfQuarters)
        {
            // Ensure valid input values
            periodOfQuarters = Math.Max(periodOfQuarters, 1);
            percentageCriteria = Math.Min(percentageCriteria, 100.0);

            var currentPeriod = new Period();
            List<StatsForCertainCriteriaResponse> response = new();

            // get maximum possible score
            var maxScore = (await _rankingRepository.SelectAllAsync<QuestionBlock, Score>(
                        e => new(e.MaxScore, 0)))
                        .Sum(s => s.Point);

            // get organizations only once and reuse
            var orgsLookup = (await _rankingRepository.SelectAllAsync<Organization, Org>(
                        o => new(o.OrganizationId, o.ShortName),
                        o => o.Status))
                        .ToDictionary(o => o.OrganizationId, o => o.Name);           

            for (int i = 0, quarter = currentPeriod.Quarter + 1,
                year = currentPeriod.Year; periodOfQuarters > i; i++)
            {
                year = quarter - 1 > 0 ? year : year - 1;
                quarter = quarter - 1 > 0 ? quarter - 1 : 4;

                var scores = (await _rankingRepository
                        .SelectAllAsync<Evaluation, Score>(
                            e => new(e.Score, e.OrganizationId),
                            e => e.Year == year && e.QuarterIndex == quarter))
                        .GroupBy(s => s.OrganizationId)
                        .Select(g => new Score(g.Sum(s => s.Point), g.Key))
                        .Where(s => s.Point / maxScore * 100 > percentageCriteria);

                var orgNames = scores.Select(s => orgsLookup.TryGetValue(s.OrganizationId, out var name) ? name : null);

                response.Add(new StatsForCertainCriteriaResponse(orgNames, new Period(year, quarter)));
            }

            return await Result<IEnumerable<StatsForCertainCriteriaResponse>>.SuccessAsync(response);
        }
       
        #region private methods
        private async Task<bool> ValidateScore(string indicator, double score)
        {
            var questionBlock = await _rankingRepository.GetFirstByParameterAsync<QuestionBlock>(e => e.BlockNumber == indicator)
                ?? throw new NotSupportedException($"Question block with number={indicator} not found!");

            if (score > questionBlock.MaxScore)
                return false;

            return true;
        }
        private async Task<bool> ValidateScoreRequest(ScoreRequest scoreRequest, int type)
            => type switch
            {
                1 => scoreRequest is ScoreRequestByIndicator indicator &&
                     await _rankingRepository.GetFirstByParameterAsync<QuestionBlock>(e => e.BlockNumber == indicator.BlockNumber) is not null,
                2 => await _rankingRepository.GetByIdAsync<Organization>(scoreRequest.OrganizationId) is not null,
                _ => false
            };
        private async Task<Result<int>> GetOrganizationId(int organizationId = 0)
        {
            if (organizationId != 0 && organizationId > 0)
            {
                var isUserAuthorizedResult = await _applicationUserService.IsUserAuthorizedForThisInfo(organizationId);

                if (!isUserAuthorizedResult.Succeeded)
                    return await Result<int>.FailAsync(String.Join(",", isUserAuthorizedResult.Messages));
                if (!isUserAuthorizedResult.Data)
                    return await Result<int>.FailAsync(
                        HttpStatusCode.Unauthorized, 
                        new List<string> {$"you are not authorized to get info of organization with id = {organizationId}"});

                return await Result<int>.SuccessAsync(organizationId);
            }
            var claimResult = await _applicationUserService.GetCurrentUserClaim(CustomClaimTypes.OrganizationId);

            if (!claimResult.Succeeded)
            {
                return await Result<int>.FailAsync(String.Join(",", claimResult.Messages));
            }

            organizationId = int.TryParse(claimResult.Data, out var value) ? value : 0;
            if (organizationId == 0)
                return await Result<int>.FailAsync($"Wrong Organizaiton Id : {claimResult.Data}");

            return await Result<int>.SuccessAsync(organizationId);
        }
        private async Task<List<ScoreForPeriod>> GetScoresForPeriod(int periodOfQuarters, double maxScore)
        {
            var currentPeriod = new Period();

            // Ensure valid input values
            periodOfQuarters = Math.Max(periodOfQuarters, 1);

            List<ScoreForPeriod> scoreForPeriods = new();

            for (int i = 0, quarter = currentPeriod.Quarter + 1,
                year = currentPeriod.Year; periodOfQuarters > i; i++)
            {
                year = quarter - 1 > 0 ? year : year - 1;
                quarter = quarter - 1 > 0 ? quarter - 1 : 4;

                var overallScore = (await _rankingRepository.SelectAllAsync<Evaluation, Score>(
                        e => new(e.Score, 0),
                         e => e.Year == year && e.QuarterIndex == quarter))
                        .Sum(e => e.Point);
                var scorePercentage = (overallScore / maxScore) * 100;
                var scoreForPeriod = new ScoreForPeriod(year, quarter, overallScore, scorePercentage);
                scoreForPeriods.Add(scoreForPeriod);
            }

            return scoreForPeriods;
        }
        #endregion
    }
}
