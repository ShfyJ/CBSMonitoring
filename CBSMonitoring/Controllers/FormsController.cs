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

        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService;
        }

        // GET: api/<FormsController>
        [HttpGet("GetFormById/{id}")]
        public async Task<IActionResult> GetFormById(int id)
        {
            var result = await _formService.GetForm(id);

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result);
        }

        // POST api/<FormsController>
        [HttpPost("CreateForm")]
        public async Task<IActionResult> CreateForm([FromForm] MonitoringFormDTO form)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var result = await _formService.AddForm(form);

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            else
                return Ok(result);
        }

        // PUT api/<FormsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<FormsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
