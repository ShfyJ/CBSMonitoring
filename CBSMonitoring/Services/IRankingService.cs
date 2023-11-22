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

        // builds score statistics of an organization for every quarters in the given period
        Task<Result<ScoreStatsReponse>> GetStatisticsForPeriod(int periodOfQuaters, int organizationId=0);
        
        // builds score statistics of all organization in one value for every quarters in the given period
        Task<Result<IEnumerable<ScoreForPeriod>>> GetAllInOneStatiscticsForPeriod(int periodOfQuarters);
        Task<Result<IEnumerable<StatsForCertainCriteriaResponse>>> GetStatsForCriteria(double percentageCriteria, int periodOfQuarters);
    }
}
