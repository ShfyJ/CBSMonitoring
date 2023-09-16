using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public class QuestionBlockService : IQuestionBlockService
    {
        private readonly IGenericRepository _qbRepository;
        private readonly IMapper _mapper;
        public QuestionBlockService(IGenericRepository qbRepository, IMapper mapper)
        {
            _qbRepository = qbRepository;
            _mapper = mapper;

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
                var indicators = await _qbRepository.GetAllByParameterAsync<MonitoringIndicator>(e => e.IsActive,
                                    query => query.Include(e => e.QuestionBlocks).ThenInclude(q => q.FormSections));

                List<MonitoringIndicatorWithQbsResponse> response = new();
                

                int sectionsCount;
                int filledSectionsCount = 0;

                foreach (var item in indicators)
                {
                    List<QuestionBlockResponse> questionBlocks = new();

                    foreach (var qb in item.QuestionBlocks)
                    {
                        sectionsCount = qb.FormSections!.Count;

                        foreach (var section in qb.FormSections!)
                        {
                            if (await _qbRepository.GetFirstByParameterAsync<OrgMonitoring>(o => o.SectionNumber == section.SectionNumber
                                                         && o.OrganizationId == request.OrganizationId && o.Year == request.Year
                                                         && o.QuarterIndex == request.Quarter) is not null)
                            {
                                filledSectionsCount++;
                            }
                        }

                        var completion = ((double)filledSectionsCount / sectionsCount) * 100;

                        var qbItem = new QuestionBlockResponse(qb.BlockId, qb.BlockNumber, qb.BlockName,
                                                qb.IsActive, qb.Point, sectionsCount, completion);

                        questionBlocks.Add(qbItem);

                        filledSectionsCount = 0;
                    }

                    var responseItem = new MonitoringIndicatorWithQbsResponse(item.Id, item.Name, item.IsActive, questionBlocks);
                    response.Add(responseItem);
                }


                return await Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>.SuccessAsync(response);
            }

            catch (Exception ex)
            {
                return await Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>.FailAsync(ex.Message);
            }
        }

        public async Task<Result<QuestionBlockResponse>> GetQuestionBlock(int questionBlockId)
        {
            var qb = await _qbRepository.GetByIdAsync<QuestionBlock>(questionBlockId);

            if (qb == null)
                return await Result<QuestionBlockResponse>.FailAsync($"Quesiton block with id={questionBlockId}");

            return await Result<QuestionBlockResponse>.SuccessAsync(_mapper.Map<QuestionBlockResponse>(qb));
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
        
        
    }
}
