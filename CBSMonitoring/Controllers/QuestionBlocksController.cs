using CBSMonitoring.Constants;
using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CBSMonitoring.DTOs.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequirePasswordChange")]
    public class QuestionBlocksController : ControllerBase
    {

        private readonly IQuestionBlockService _qbService;

        public QuestionBlocksController(IQuestionBlockService qbService)
        {
            _qbService = qbService;
        }

        [HttpGet("GetQuestionBlockById/{id}")]
        public async Task<IActionResult> GetQuestionBlockById(int id)
        {
            var result = await _qbService.GetQuestionBlock(id);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("CreateQuestionBlock")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateQuestionBlock([FromForm] QuestionBlockRequest qb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _qbService.AddQuestionBlock(qb);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("GetQuestionBlocks")]
        public async Task<IActionResult> GetQuestionBlocks([FromBody] LevelRequest request)
        {
            var result = await _qbService.GetQuestionBlocksWithIndicators(request);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("GetRawQuestionBlocks")]
        public async Task<IActionResult> GetRawQuestionBlocks()
        {
            var result = await _qbService.GetRawQuestionBlocksWithIndicators();

            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("UpdateQuestionBlock/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateQuestionBlock([FromForm] QuestionBlockRequest qb, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _qbService.UpdateQuestionBlock(qb, id);

            return StatusCode(result.StatusCode, result);

        }

        [HttpDelete("DeleteQuestionBlock/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteQuestionBlock(int id)
        {
            var result = await _qbService.RemoveQuestionBlock(id);

            return StatusCode(result.StatusCode, result);
        }
    }
}
