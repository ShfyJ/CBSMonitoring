using AutoMapper;
using CBSMonitoring.Constants;
using CBSMonitoring.Models;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CBSMonitoring.DTOs.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    [Authorize(Policy = "RequirePasswordChange")]
    public class FormItemTypesController : ControllerBase
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;
        public FormItemTypesController(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        // GET: api/<CataloguesController>
        [HttpGet("GetFormItemType")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CataloguesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CataloguesController>
        [HttpPost]
        public async Task<IActionResult> CreateFormItemType([FromForm] FormItemTypeRequest formItemTypeRequest)
        {
            var itemType = _mapper.Map<Models.FormItemType>(formItemTypeRequest);
            try
            {
                await _genericRepository.AddAsync(itemType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success");
        }

        // PUT api/<CataloguesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CataloguesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
