using AutoMapper;
using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

        public async Task<Result<IEnumerable<QuestionBlockResponse>>> GetQuestionBlocks(bool? isActive)
        {
            try
            {
                var questionBlocks = await _qbRepository.GetAllAsync<QuestionBlock>();
                if(isActive is not null)
                {
                    questionBlocks = questionBlocks.Where(q => q.IsActive).ToList();
                }
                
                List<QuestionBlockResponse> qbDTOs = new();

                foreach(var questionBlock in questionBlocks)
                {
                    QuestionBlockResponse questionBlockResponse = _mapper.Map<QuestionBlockResponse>(questionBlock);

                    qbDTOs.Add(questionBlockResponse);
                }

                return await Result<IEnumerable<QuestionBlockResponse>>.SuccessAsync(qbDTOs);
            }
            
            catch(Exception ex)
            {
                return await Result<IEnumerable<QuestionBlockResponse>>.FailAsync(ex.Message);
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

            catch(Exception ex)
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
