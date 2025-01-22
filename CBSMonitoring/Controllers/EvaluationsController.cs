using CBSMonitoring.Constants;
using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequirePasswordChange")]
    public class EvaluationsController : ControllerBase
    {
        private readonly IRankingService _rankingService;
        private readonly IApplicationUserService _applicationUserService;
        public EvaluationsController(IRankingService rankingService, IApplicationUserService applicationUserService)
        {
            _rankingService = rankingService;
            _applicationUserService = applicationUserService;
        }

        [HttpPost("GetRankingsOfOrganizationsByIndicator/")]
        public async Task<IActionResult> GetRankingsOfOrganizationsByIndicator([FromBody] ScoreRequestByIndicator scoreRequest)
        {
            var result = await _rankingService.GetRankingsOfOrganizationsByIndicator(scoreRequest);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("GetRankingsOfOrganizations")]
        public async Task<IActionResult> GetRankingsOfOrganizations([FromBody] Period period)
        {
            var result = await _rankingService.GetRankingsOfOrganizations(period);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("GetEvaluationOfIndicator")]
        public async Task<IActionResult> GetEvaluationOfIndicator([FromBody] ScoreRequestByIndicator scoreRequest)
        {

            var result = await _rankingService.GetEvaluationOfIndicator(scoreRequest);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("GetScoresOfOrganization")]
        public async Task<IActionResult> GetScoresOfOrganization([FromBody] ScoreRequest scoreRequest)
        {
            var result = await _rankingService.GetScoresOfOrganization(scoreRequest);

            return StatusCode(result.StatusCode, result);

        }

        [HttpPost("Evaluate")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Evaluate([FromBody] EvaluationRequest evaluationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rankingService.Evaluate(evaluationRequest);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("ReEvaluate")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> ReEvaluate([FromBody]ReEvaluationRequest reEvaluationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rankingService.ReEvaluate(reEvaluationRequest);
            
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("RemoveEvaluation/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RemoveEvaluation(int id)
        {
            var result = await _rankingService.RemoveEvaluation(id);

            return StatusCode(result.StatusCode, result);
        }

        
    }
}
