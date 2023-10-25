using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using System.Runtime.CompilerServices;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IRankingService
    {
        Task<Result<string>> Evaluate(EvaluationRequest evaluationRequest);
        Task<Result<ScoreResponse>> GetEvaluationOfIndicator(ScoreRequestByIndicator scoreRequest);
        Task<Result<IEnumerable<ScoreResponse>>> GetRankingsOfOrganizationsByIndicator(ScoreRequestByIndicator scoreRequest);
        Task<Result<IEnumerable<RankingResponse>>> GetRankingsOfOrganizations(Period? period);
        Task<Result<IEnumerable<ScoreResponse>>> GetScoresOfOrganization(ScoreRequest scoreRequest);
        Task<Result<string>> ReEvaluate(ReEvaluationRequest reEvaluationRequest);
        Task<Result<string>> RemoveEvaluation(int id);
    }
}
