using CBSMonitoring.DTOs;
using ERPBlazor.Shared.Wrappers;
using System.Runtime.CompilerServices;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IQuestionBlockService
    {
        Task<Result<string>> AddQuestionBlock(QuestionBlockRequest questionBlock);
        Task<Result<string>> RemoveQuestionBlock(int questionBlockId);
        Task<Result<string>> UpdateQuestionBlock(QuestionBlockRequest questionBlock, int id);
        Task<Result<RawQuestionBlockResponse>> GetQuestionBlock(int questionBlockId);
        Task<Result<IEnumerable<MonitoringIndicatorWithQbsResponse>>> GetQuestionBlocksWithIndicators(LevelRequest request);
        Task<Result<IEnumerable<MonitoringIndicatorWithRawQbsResponse>>> GetRawQuestionBlocksWithIndicators();
        Task<Result<StatsForReportCompletionResponse>> GetStatsForReportCompletion(int periodOfQuarters, int organizationId);
        Task<Result<IEnumerable<CompletionForPeriod>>> GetAllInOneStatsForReportCompletion(int periodOfQuarters);
    }
}
