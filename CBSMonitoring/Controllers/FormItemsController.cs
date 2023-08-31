using CBSMonitoring.Services;
using Microsoft.AspNetCore.Mvc;
using static CBSMonitoring.DTOs.Requests;

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
        [HttpGet("GetByFormSectionId/{id}")]
        public async Task<IActionResult> GetByFormSectionId(int id)
        {
            var result = await _formItemService.GetFormItemsByFormSectionId(id);

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result);
        }

        // GET api/<FormItemController>/5
        [HttpGet("GetItemById/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var result = await _formItemService.GetFormItem(id);

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result);
        }

        // POST api/<FormItemController>
        [HttpPost("CreateFormItem")]
        public async Task<IActionResult> CreateFormItem([FromForm] FormItemRequest item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _formItemService.AddFormItem(item);

            if (!result.Succeeded)
            {
                return BadRequest(result.Messages);
            }

            return Ok(result);

        }

        // PUT api/<FormItemController>/5
        [HttpPut("UpdateFormItem/{id}")]
        public async Task<IActionResult> UpdateFormItem([FromForm] FormItemRequest item, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _formItemService.EditFormItem(item, id);
            if (!result.Succeeded)
                return BadRequest(result.Messages);
            return Ok(result);
        }

        // DELETE api/<FormItemController>/5
        [HttpDelete("DeleteFormItem/{id}")]
        public async Task<IActionResult> DeleteFormItem(int id)
        {
            var result = await _formItemService.DeleteFormItem(id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);
            return Ok(result);
        }
    }
}
