using AutoMapper;
using CBSMonitoring.Constants;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>> GetQuestionBlocksWithIndicators(LevelRequest request)
        {
            try
            {
                
                // Get current user's organization id or check if user is authorized for this organization info
                var orgIdResult = await GetOrganizationId(request.OrganizationId);
                
                if (!orgIdResult.Succeeded)
                {
                    return await Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>.FailAsync(orgIdResult.Messages);
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

                        return new QuestionBlockResponse(qb.QbId, qb.QbNumber, qb.QbName,
                                                    qb.QbMaxScore, sectionsCount, completion,
                                                    evaluation?.Score, evaluation?.Id);
                    });

                    return new MonitoringIndicatorWithQbsResponse(indicator.Id, indicator.Name, questionBlocks);
                });

                return await Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>.SuccessAsync(response);
            }

            catch (Exception ex)
            {
                return await Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>.FailAsync(ex.Message);
            }

        }

        public async Task<Result<RawQuestionBlockResponse>> GetQuestionBlock(int questionBlockId)
        {
            var qb = await _qbRepository.GetByIdAsync<QuestionBlock>(questionBlockId);

            if (qb == null)
                return await Result<RawQuestionBlockResponse>.FailAsync($"Quesiton block with id={questionBlockId}");

            return await Result<RawQuestionBlockResponse>.SuccessAsync(_mapper.Map<RawQuestionBlockResponse>(qb));
        }

        public async Task<Result<string>> RemoveQuestionBlock(int questionBlockId)
        {
            var questionBlock = await _qbRepository.GetByIdAsync<QuestionBlock>(questionBlockId);
            if (questionBlock == null)
                return await Result<string>.FailAsync($"Question blocj with id={questionBlockId}");

            try
            {
                await _qbRepository.DeleteAsync(questionBlock);
            }

            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<string>> UpdateQuestionBlock(QuestionBlockRequest questionBlock, int id)
        {
            var qb = await _qbRepository.GetByIdAsync<QuestionBlock>(id);

            if (qb == null)
                return await Result<string>.FailAsync($"Question block with id={id} not found");

            _mapper.Map(questionBlock, qb);

            await _qbRepository.UpdateAsync(qb);

            return await Result<string>.SuccessAsync($"Success");
        }
        private async Task<Result<int>> GetOrganizationId(int organizationId)
        {
            if (organizationId != 0 && organizationId > 0)
            {
                var isUserAuthorizedResult = await _applicationUserService.IsUserAuthorizedForThisInfo(organizationId);

                if (!isUserAuthorizedResult.Succeeded || !isUserAuthorizedResult.Data)
                    return await Result<int>.FailAsync($"{isUserAuthorizedResult.Messages}");

                return await Result<int>.SuccessAsync(organizationId);
            }
            var claimResult = await _applicationUserService.GetCurrentUserClaim(CustomClaimTypes.OrganizationId);

            if (!claimResult.Succeeded)
            {
                return await Result<int>.FailAsync(claimResult.Messages);
            }

            organizationId = int.TryParse(claimResult.Data, out var value) ? value : 0;
            if (organizationId == 0)
                return await Result<int>.FailAsync($"Wrong Organizaiton Id : {claimResult.Data}");

            return await Result<int>.SuccessAsync(organizationId);
        }

    }
}
