using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormItemsController : ControllerBase
    {
        private readonly IFormItemService _formItemService;
        public FormItemsController(IFormItemService formItemService)
        {
            _formItemService = formItemService;
        }
        // GET: api/<FormItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FormItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FormItemController>
        [HttpPost("CreateFormItem")]
        public async Task<IActionResult> CreateFormItem([FromBody] FormItemDTO item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _formItemService.AddFormItem(item);

            if(!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result);

        }

        // PUT api/<FormItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FormItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
