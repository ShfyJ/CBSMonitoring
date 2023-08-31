using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result);
        }

        [HttpPost("CreateQuestionBlock")]
        public async Task<IActionResult> CreateQuestionBlock([FromForm] QuestionBlockRequest qb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _qbService.AddQuestionBlock(qb);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        [HttpGet("GetQuestionBlocks/{status}")]
        public async Task<IActionResult> GetQuesionBlocks(bool? status = null)
        {
            var result = await _qbService.GetQuestionBlocks(status);

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result);
        }

        [HttpPut("UpdateQuestionBlock/{id}")]
        public async Task<IActionResult> UpdateQuestionBlock([FromForm] QuestionBlockRequest qb, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _qbService.UpdateQuestionBlock(qb, id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);
            else
                return Ok(result);

        }

        [HttpDelete("DeleteQuestionBlock/{id}")]
        public async Task<IActionResult> DeleteQuestionBlock(int id)
        {
            var result = await _qbService.RemoveQuestionBlock(id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            else
            {
                return Ok(result);
            }
        }
    }
}
