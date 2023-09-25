using CBSMonitoring.DTOs;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public class RankingService : IRankingService
    {
        private readonly IGenericRepository _rankingRepository;
        public RankingService(IGenericRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }
        public Task<Result<string>> Evaluate(EvaluationRequest evaluationRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ScoreResponse>> GetEvaluationOfIndicator(ScoreRequest scoreRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ScoreResponse>>> GetRankingsOfOrganizationsByIndicator(ScoreRequest scoreRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ScoreResponse>>> GetScoresOfOrganization(ScoreRequest scoreRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> ReEvaluate(ReEvaluationRequest reEvaluationRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> RemoveEvaluation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
