using CBSMonitoring.DTOs;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public interface IQuestionBlockService
    {
        Task<Result<string>> AddQuestionBlock(QuestionBlockInDTO questionBlock);
        Task<Result<string>> RemoveQuestionBlock(int  questionBlockId);
        Task<Result<string>> UpdateQuestionBlock(QuestionBlockInDTO questionBlock, int id);
        Task<Result<QuestionBlockOutDTO>> GetQuestionBlock(int questionBlockId);
        Task<Result<IEnumerable<QuestionBlockOutDTO>>> GetAllActiveQuestionBlocks();
    }
}
