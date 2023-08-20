using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {

        private readonly IQuestionBlockService _formService;

        public FormsController(IQuestionBlockService formService)
        {
            _formService = formService;
        }

        // GET: api/<FormsController>
        [HttpGet("GetFormById/{id}")]
        public async Task<IActionResult> GetFormById(int id)
        {
            var result = await _formService.GetQuestionBlock(id);

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result);
        }

        // POST api/<FormsController>
        [HttpPost("CreateForm")]
        public async Task<IActionResult> CreateForm([FromForm] MonitoringDTO form)
        {
            throw new NotImplementedException();
        }

        // PUT api/<FormsController>/5
        [HttpPut("UpdateForm")]
        public async Task<IActionResult> UpdateForm([FromForm]MonitoringDTO form )
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var result = await _formService.EditForm(form);

            //if(!result.Succeeded)
            //    return BadRequest(result.Messages);
            //else
            //    return Ok(result);
            throw new NotImplementedException();

        }

        // DELETE api/<FormsController>/5
        [HttpDelete("DeleteForm/{id}")]
        public async Task<IActionResult> DeleteForm(int id)
        {
            //var result = await _formService.DeleteForm(id);
            //if (!result.Succeeded)
            //    return BadRequest(result.Messages);

            //else
            //{
            //    return Ok(result);
            //}
            throw new NotImplementedException();
        }
    }
}
