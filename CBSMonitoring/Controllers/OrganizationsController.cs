using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CBSMonitoring.DTOs.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CBSMonitoring.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationInterface;
        public OrganizationsController(IOrganizationService organizationInterface)
        {
            _organizationInterface = organizationInterface;
        }
        // GET: api/<OrganizationsController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _organizationInterface.GetAllOrganizations();

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        // GET api/<OrganizationsController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _organizationInterface.GetOrganizationById(id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        // POST api/<OrganizationsController>
        [HttpPost("AddOrganization")]
        public async Task<IActionResult> AddOrganization([FromBody] OrganizationRequest request)
        {
            var result = await _organizationInterface.AddOrganization(request);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        // PUT api/<OrganizationsController>/5
        [HttpPut("UpdateOrgInfo{id}")]
        public async Task<IActionResult> UpdateOrgInfo(int id, [FromBody] OrganizationRequest request)
        {
            var result = await _organizationInterface.UpdateOrganizationInfo(request, id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        // DELETE api/<OrganizationsController>/5
        [HttpDelete("DeleteOrg/{id}")]
        public async Task<IActionResult> DeleteOrg(int id)
        {
            var result = await _organizationInterface.Delete(id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }
    }
}
