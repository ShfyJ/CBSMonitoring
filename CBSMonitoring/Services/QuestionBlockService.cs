using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace CBSMonitoring.Services
{
    public class QuestionBlockService : IQuestionBlockService
    {
        private readonly IGenericRepository<QuestionBlock> _qbRepository;
        public QuestionBlockService(IGenericRepository<QuestionBlock> qbRepository)
        {
            _qbRepository = qbRepository;

        }
        public async Task<Result<string>> AddQuestionBlock(QuestionBlockInDTO questionBlock)
        {
            QuestionBlock qb = new()
            {
                BlockName = questionBlock.BlockName,
                BlockNumber = questionBlock.BlockNumber,
                IsActive = questionBlock.IsActive
            };

            try
            {
                await _qbRepository.Add(qb);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<IEnumerable<QuestionBlockOutDTO>>> GetAllActiveQuestionBlocks()
        {
            try
            {
                var questionBlocks = await _qbRepository.GetAll();
                List<QuestionBlock> qbs = questionBlocks.Where(q => q.IsActive).ToList();

                List<QuestionBlockOutDTO> qbDTOs = new();

                foreach(var questionBlock in qbs)
                {
                    QuestionBlockOutDTO questionBlockOutDTO = new()
                    {
                        BlockId = questionBlock.BlockId,
                        BlockName = questionBlock.BlockName,
                        BlockNumber=questionBlock.BlockNumber,
                        IsActive = questionBlock.IsActive
                    };

                    qbDTOs.Add(questionBlockOutDTO);
                }

                return await Result<IEnumerable<QuestionBlockOutDTO>>.SuccessAsync(qbDTOs);
            }
            
            catch(Exception ex)
            {
                return await Result<IEnumerable<QuestionBlockOutDTO>>.FailAsync(ex.Message);
            }
        }

        public async Task<Result<QuestionBlockOutDTO>> GetQuestionBlock(int questionBlockId)
        {
            var qb = await _qbRepository.GetById(questionBlockId);

            if (qb == null)
                return await Result<QuestionBlockOutDTO>.FailAsync($"Quesiton block with id={questionBlockId}");

            QuestionBlockOutDTO questionBlockOutDTO = new()
            {
                BlockId=qb.BlockId,
                BlockName = qb.BlockName,
                BlockNumber=qb.BlockNumber,
                IsActive = qb.IsActive
            };

            return await Result<QuestionBlockOutDTO>.SuccessAsync(questionBlockOutDTO);
        }

        public async Task<Result<string>> RemoveQuestionBlock(int questionBlockId)
        {
            var questionBlock = await _qbRepository.GetById(questionBlockId);
            if (questionBlock == null)
                return await Result<string>.FailAsync($"Question blocj with id={questionBlockId}");

            try
            {
                await _qbRepository.Delete(questionBlock);
            }

            catch(Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<string>> UpdateQuestionBlock(QuestionBlockInDTO questionBlock, int id)
        {
            var qb = await _qbRepository.GetById(id);

            if (qb == null)
                return await Result<string>.FailAsync($"Question block with id={id} not found");

            qb.BlockNumber = questionBlock.BlockNumber;
            qb.IsActive = questionBlock.IsActive;
            qb.BlockName = questionBlock.BlockName;
            
            await _qbRepository.Update(qb);

            return await Result<string>.SuccessAsync($"Success");
        }
    }
}
