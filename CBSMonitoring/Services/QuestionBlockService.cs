using AutoMapper;
using CBSMonitoring.Constants;
using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Model;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public class QuestionBlockService : IQuestionBlockService
    {
        private readonly IGenericRepository _qbRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _applicationUserService;
        private record SelectedIndicator(int Id, string Name, IEnumerable<SelectedQb> QuestionBlocks);
        private record SelectedQb(int QbId, string QbName, string QbNumber, int QbMaxScore, IEnumerable<string> SectionNumbers);
        private record SelectedQbInShort(string QbNumber, IEnumerable<string> SectionNumbers);
        private record SelectedReport(string SectionNumber, Period Period);
        public QuestionBlockService(IGenericRepository qbRepository, IMapper mapper,
            IApplicationUserService applicationUserService)
        {
            _qbRepository = qbRepository;
            _mapper = mapper;
            _applicationUserService = applicationUserService;

        }
        public async Task<Result<string>> AddQuestionBlock(QuestionBlockRequest questionBlock)
        {
            QuestionBlock qb = _mapper.Map<QuestionBlock>(questionBlock);

            try
            {
                await _qbRepository.AddAsync(qb);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Неуспешно: {ex.Message}");
            }

            return await Result<string>.SuccessAsync($"Успешно!");
        }

        public async Task<Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>> GetQuestionBlocksWithIndicators(LevelRequest request)
        {
            try
            {

                // Get current user's organization id or check if user is authorized for this organization info
                var orgIdResult = await GetOrganizationId(request.OrganizationId);

                if (!orgIdResult.Succeeded)
                {
                    return await Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>.FailAsync(
                    orgIdResult.Code, orgIdResult.Messages);
                }

                request.OrganizationId = orgIdResult.Data;
                Stopwatch stopWatch = Stopwatch.StartNew();
                stopWatch.Start();
                var indicators = await _qbRepository.SelectAllAsync<MonitoringIndicator, SelectedIndicator>(
                    e => new SelectedIndicator(
                        e.Id,
                        e.Name,
                        e.QuestionBlocks.Select(qb =>
                            new SelectedQb(
                                qb.BlockId,
                                qb.BlockName,
                                qb.BlockNumber,
                                qb.MaxScore,
                                qb.FormSections.Select(s => s.SectionNumber)
                            )
                        )
                    ),
                    e => e.IsActive);
                stopWatch.Stop();
                Console.WriteLine($"time1: {stopWatch.ElapsedMilliseconds} ms");
                // fetch monitoring reports for the given criteria
                // and convert it to dictionary with key => section number

                var reportsLookup = (await _qbRepository.GetAllAsync<OrgMonitoring>(
                    o => o.OrganizationId == request.OrganizationId &&
                    o.Year == request.Period.Year &&
                    o.QuarterIndex == request.Period.Quarter)
                    ).ToDictionary(r => r.SectionNumber, r => r);

                // fetch evaluations for the given criteria
                var evaluationsLookup = (await _qbRepository.GetAllAsync<Evaluation>(
                    e => e.OrganizationId == request.OrganizationId &&
                    e.Year == request.Period.Year &&
                    e.QuarterIndex == request.Period.Quarter)
                    ).ToDictionary(e => e.BlockNumber, e => e);


                var response = indicators.Select(indicator =>
                {
                    var questionBlocks = indicator.QuestionBlocks.Select(qb =>
                    {
                        var sectionsCount = qb.SectionNumbers.Count();
                        var filledSectionsCount = qb.SectionNumbers.Count(sectionNumber =>
                            reportsLookup.ContainsKey(sectionNumber));
                        var completion = (double)filledSectionsCount / sectionsCount * 100;

                        evaluationsLookup.TryGetValue(qb.QbNumber, out var evaluation);

                        var newReportsCountAddedAfterEvaluation = reportsLookup.Count(r =>
                            r.Value.CreatedDateTime > evaluation?.EvaluatedTime);

                        return new QuestionBlockResponse(qb.QbId, qb.QbNumber, qb.QbName,
                                                    qb.QbMaxScore, sectionsCount, completion,
                                                    evaluation?.Score, evaluation?.Id, evaluation?.Comment,
                                                    newReportsCountAddedAfterEvaluation > 0, newReportsCountAddedAfterEvaluation);
                    });

                    return new MonitoringIndicatorWithQbsResponse(indicator.Id, indicator.Name, questionBlocks);
                });

                return await Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>.SuccessAsync(response);
            }

            catch (Exception ex)
            {
                return await Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>.FailAsync($"Неуспешно: {ex.Message}");
            }

        }
        public async Task<Result<IEnumerable<MonitoringIndicatorWithRawQbsResponse>>> GetRawQuestionBlocksWithIndicators()
        {
            try
            {

                Stopwatch stopWatch = Stopwatch.StartNew();
                stopWatch.Start();
                var indicators = await _qbRepository.SelectAllAsync<MonitoringIndicator, MonitoringIndicatorWithRawQbsResponse>(
                    e => new MonitoringIndicatorWithRawQbsResponse(
                        e.Id,
                        e.Name,
                        e.QuestionBlocks.Select(qb =>
                            new RawQuestionBlockResponse(
                                qb.BlockId,
                                qb.BlockNumber,
                                qb.BlockName,
                                qb.IsActive,
                                qb.MaxScore,
                                qb.FormSections.Count
                            )
                        )
                    ));
                stopWatch.Stop();
                Console.WriteLine($"time1: {stopWatch.ElapsedMilliseconds} ms");

                return await Result<IEnumerable<MonitoringIndicatorWithRawQbsResponse>>.SuccessAsync(indicators);
            }

            catch (Exception ex)
            {
                return await Result<IEnumerable<MonitoringIndicatorWithRawQbsResponse>>.FailAsync($"Неуспешно: {ex.Message}");
            }
        }
        public async Task<Result<RawQuestionBlockResponse>> GetQuestionBlock(int questionBlockId)
        {
            var qb = await _qbRepository.GetByIdAsync<QuestionBlock>(questionBlockId);

            if (qb == null)
                return await Result<RawQuestionBlockResponse>.FailAsync($"Блок вопросов с id={questionBlockId} не найден!");

            return await Result<RawQuestionBlockResponse>.SuccessAsync(_mapper.Map<RawQuestionBlockResponse>(qb));
        }
        public async Task<Result<string>> RemoveQuestionBlock(int questionBlockId)
        {
            var questionBlock = await _qbRepository.GetByIdAsync<QuestionBlock>(questionBlockId);
            if (questionBlock == null)
                return await Result<string>.FailAsync($"Блок вопросов с id={questionBlockId} не найден!");

            try
            {
                await _qbRepository.DeleteAsync(questionBlock);
            }

            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Неуспешно: {ex.Message}");
            }

            return await Result<string>.SuccessAsync($"Успешно!");
        }
        public async Task<Result<string>> UpdateQuestionBlock(QuestionBlockRequest questionBlock, int id)
        {
            var qb = await _qbRepository.GetByIdAsync<QuestionBlock>(id);

            if (qb == null)
                return await Result<string>.FailAsync($"Блок вопросов с id={id} не найден!");

            _mapper.Map(questionBlock, qb);

            await _qbRepository.UpdateAsync(qb);

            return await Result<string>.SuccessAsync($"Успешно!");
        }
        public async Task<Result<StatsForReportCompletionResponse>> GetStatsForReportCompletion(int periodOfQuarters, int organizationId)
        {
            var currentPeriod = new Period();
            List<Period> periods = GeneratePeriods(currentPeriod.Year, currentPeriod.Quarter, periodOfQuarters);

            // Get current user's organization id or check if user is authorized for this organization info
            var orgIdResult = await GetOrganizationId(organizationId);

            if (!orgIdResult.Succeeded)
            {
                return await Result<StatsForReportCompletionResponse>.FailAsync(
                    orgIdResult.Code, orgIdResult.Messages);
            }

            organizationId = orgIdResult.Data;

            // Fetch organization name by requested organizationId
            var organizationName = await FetchOrganizationNameAsync(organizationId);

            // Fetch and group reports
            var groupedReportSectNumbers = await FetchAndGroupReportsAsync(periods, organizationId);

            // Fetch question blocks
            var questionBlocks = await FetchQuestionBlocksAsync();

            // Calculate completions for each period
            var completions = CalculateCompletions(periods, groupedReportSectNumbers, questionBlocks);

            var response = new StatsForReportCompletionResponse(organizationId, organizationName, completions);

            return await Result<StatsForReportCompletionResponse>.SuccessAsync(response);
        }

        public async Task<Result<IEnumerable<CompletionForPeriod>>> GetAllInOneStatsForReportCompletion(int periodOfQuarters)
        {
            var currentPeriod = new Period();
            List<Period> periods = GeneratePeriods(currentPeriod.Year, currentPeriod.Quarter, periodOfQuarters);

            // Fetch and group reports
            var groupedGroupReportSectNumbers = await FetchAndGroupReportsAsync(periods);

            // Fetch question blocks
            var questionBlocks = await FetchQuestionBlocksAsync();

            // Get the number of active organizations
            var numberOfActiveOrgs = await CountActiveOrganizations();

            // Calculate completions for each period
            var completions = CalculateCompletions(periods, groupedGroupReportSectNumbers, questionBlocks, numberOfActiveOrgs);

            return await Result<IEnumerable<CompletionForPeriod>>.SuccessAsync(completions);
        }

        #region private methods
        private async Task<Result<int>> GetOrganizationId(int organizationId)
        {
            if (organizationId != 0 && organizationId > 0)
            {
                var isUserAuthorizedResult = await _applicationUserService.IsUserAuthorizedForThisInfo(organizationId);

                if (!isUserAuthorizedResult.Succeeded || !isUserAuthorizedResult.Data)
                    return await Result<int>.FailAsync(isUserAuthorizedResult.Messages);

                return await Result<int>.SuccessAsync(organizationId);
            }
            var claimResult = await _applicationUserService.GetCurrentUserClaim(CustomClaimTypes.OrganizationId);

            if (!claimResult.Succeeded)
            {
                return await Result<int>.FailAsync(claimResult.Messages);
            }

            organizationId = int.TryParse(claimResult.Data, out var value) ? value : 0;
            if (organizationId == 0)
                return await Result<int>.FailAsync($"Неправильный идентификатор организации: {claimResult.Data}");

            return await Result<int>.SuccessAsync(organizationId);
        }

        // Method to generate periods based on the given criteria
        private static List<Period> GeneratePeriods(int startYear, int startQuarter, int periodOfQuarters)
        {
            var periods = new List<Period>();

            for (int i = 0; i < periodOfQuarters; i++)
            {
                int year = startQuarter - i > 0 ? startYear : startYear - 1;
                int quarter = startQuarter - i > 0 ? startQuarter - i : 4;
                periods.Add(new Period(year, quarter));
            }

            return periods;
        }

        // Method to fetch organization name asynchronously
        private async Task<string?> FetchOrganizationNameAsync(int organizationId)
        {
            return await _qbRepository.SelectFirstByParameterAsync<Organization, string>(
                o => o.OrganizationId == organizationId,
                o => o.FullName);
        }

        // Method to fetch and group reports asynchronously
        private async Task<Dictionary<Period, List<string>>> FetchAndGroupReportsAsync(List<Period> periods, int organizationId = 0)
        {
            try
            {
                var reportsQuery = organizationId != 0
                     ? _qbRepository.SelectAllAsync<OrgMonitoring, SelectedReport>(
                        r => new SelectedReport(r.SectionNumber, new(r.Year, r.QuarterIndex)),
                        r => periods.Select(p => p.Year).Any(p => p == r.Year) &&
                             periods.Select(p => p.Quarter).Any(p => p == r.QuarterIndex) &&
                             r.OrganizationId == organizationId)

                     : _qbRepository.SelectAllAsync<OrgMonitoring, SelectedReport>(
                        r => new SelectedReport(r.SectionNumber, new(r.Year, r.QuarterIndex)),
                        r => periods.Select(p => p.Year).Any(p => p == r.Year) &&
                             periods.Select(p => p.Quarter).Any(p => p == r.QuarterIndex));

                var reportsResult = await reportsQuery;

                return reportsResult
                                .GroupBy(r => r.Period)
                                .ToDictionary(g => g.Key, g => g.Select(s => s.SectionNumber).ToList());

            }
            catch (Exception ex)
            {
                var mes = ex.Message;
            }

            return new Dictionary<Period, List<string>>();
        }

        // Method to fetch question blocks asynchronously
        private async Task<IEnumerable<SelectedQbInShort>> FetchQuestionBlocksAsync()
        {
            return await _qbRepository.SelectAllAsync<QuestionBlock, SelectedQbInShort>(
                q => new(q.BlockNumber, q.FormSections.Select(s => s.SectionNumber)),
                q => q.IsActive,
                query => query.Include(q => q.FormSections));
        }

        // Method to calculate completions for each period
        private static IEnumerable<CompletionForPeriod> CalculateCompletions(List<Period> periods, Dictionary<Period, List<string>> groupedReportSectNumbers,
            IEnumerable<SelectedQbInShort> questionBlocks, int numberOfOrgs = 1)
        {
            return numberOfOrgs switch {

                // gets the completions of single org
                1 => periods.Select(period =>
                {
                    if (groupedReportSectNumbers.TryGetValue(period, out var selectedSectNumbers))
                    {
                        var qbsCompletions = questionBlocks.Select(qb =>
                    {
                        var countOfQbSectNumbers = qb.SectionNumbers.Count(sectionNumber => selectedSectNumbers.Contains(sectionNumber));
                        return (double)countOfQbSectNumbers / qb.SectionNumbers.Count();
                    });

                        var completion = qbsCompletions.Sum() / questionBlocks.Count() * 100;
                        return new CompletionForPeriod(period, completion);
                    }

                    return new CompletionForPeriod(period, null);
                }),

                // gets the average completions of orgs
                _ => periods.Select(period =>
                {
                    if (groupedReportSectNumbers.TryGetValue(period, out var selectedSectNumbers))
                    {
                        var qbsCompletions = questionBlocks.Select(qb =>
                        {
                            var countOfQbSectNumbers = qb.SectionNumbers.Count(sectionNumber => selectedSectNumbers.Contains(sectionNumber));
                            return (double)countOfQbSectNumbers / qb.SectionNumbers.Count();
                        });

                        var completion = qbsCompletions.Sum() / questionBlocks.Count() * 100 / numberOfOrgs; 
                        return new CompletionForPeriod(period, completion);
                    }

                    return new CompletionForPeriod(period, null);
                })
            };
        }

        // Method to fetch organizations and count asynchronously
        private async Task<int> CountActiveOrganizations()
        {
            return (await _qbRepository
                   .GetAllAsync<Organization>(o => o.Status))
                   .Count();
        }

        #endregion

    }
}
