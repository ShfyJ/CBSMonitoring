using CBSMonitoring.DTOs;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IQuestionBlockService
    {
        Task<Result<string>> AddQuestionBlock(QuestionBlockRequest questionBlock);
        Task<Result<string>> RemoveQuestionBlock(int questionBlockId);
        Task<Result<string>> UpdateQuestionBlock(QuestionBlockRequest questionBlock, int id);
        Task<Result<QuestionBlockResponse>> GetQuestionBlock(int questionBlockId);
        Task<Result<IEnumerable<QuestionBlockResponse>>> GetQuestionBlocks(LevelRequest request);
    }
}
