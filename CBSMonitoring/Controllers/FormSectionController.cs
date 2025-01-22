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
    public class FormSectionsController : ControllerBase
    {
        private readonly IFormSectionService _fsService;

        public FormSectionsController(IFormSectionService fsService)
        {
            _fsService = fsService;
        }
        // GET: api/<FormSectionController>
        [HttpGet("GetFormSectionById/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetFormSectionById(int id)
        {
            var result = await _fsService.GetFormSectionById(id);

            return StatusCode(result.StatusCode, result);
        }

        // GET api/<FormSectionController>/5
        [HttpPost("GetFormSectionsByQbId/{id}")]
        public async Task<IActionResult> GetFormSectionsByQbId(LevelRequest request, int id)
        {
            var result = await _fsService.GetAllFormSectionsByQuestionBlockId(id, request);

            return StatusCode(result.StatusCode, result);
        }

        // POST api/<FormSectionController>
        [HttpPost("CreateFormSection")]
        [Authorize(Roles = UserRoles.Admin)]
        [NonAction]
        public async Task<IActionResult> CreateFormSection([FromForm] FormSectionRequest fs)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );
                return BadRequest(errors);
            }

            var result = await _fsService.AddFormSection(fs);
            return StatusCode(result.StatusCode, result);
        }

        // PUT api/<FormSectionController>/5
        [HttpPut("UpdateFormSection/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateFormSection(int id, [FromForm] FormSectionRequest fs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _fsService.EditFormSection(fs, id);

            return StatusCode(result.StatusCode, result);
        }

        // DELETE api/<FormSectionController>/5
        [HttpDelete("DeleteFormSection/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        [NonAction]
        public async Task<IActionResult> DeleteFormSection(int id)
        {
            var result = await _fsService.DeleteFormSection(id);

            return StatusCode(result.StatusCode, result);
        }
    }
}
