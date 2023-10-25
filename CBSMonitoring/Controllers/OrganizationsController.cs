using CBSMonitoring.Constants;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CBSMonitoring.DTOs.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CBSMonitoring.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IApplicationUserService _applicationUserService;
        public OrganizationsController(IOrganizationService organizationService, IApplicationUserService applicationUserService)
        {
            _organizationService = organizationService;
            _applicationUserService = applicationUserService;
        }
        // GET: api/<OrganizationsController>
        [HttpGet("GetAll")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _organizationService.GetAllOrganizations();

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        [HttpGet("GetAllWithShortInfo")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetAllWithShortInfo()
        {
            var result = await _organizationService.GetAllOrganizationsInShort();

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        // GET api/<OrganizationsController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var chekingResult = await _applicationUserService.IsUserAuthorizedForThisInfo(id);

            if(!chekingResult.Succeeded)
                return BadRequest(chekingResult.Messages);

            var result = await _organizationService.GetOrganizationById(id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        // POST api/<OrganizationsController>
        [HttpPost("AddOrganization")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddOrganization([FromBody] OrganizationRequest request)
        {
            var result = await _organizationService.AddOrganization(request);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        // PUT api/<OrganizationsController>/5
        [HttpPut("UpdateOrgInfo/{id}")]
        public async Task<IActionResult> UpdateOrgInfo(int id, [FromBody] OrganizationRequest request)
        {

            var chekingResult = await _applicationUserService.IsUserAuthorizedForThisInfo(id);

            if (!chekingResult.Succeeded)
                return BadRequest(chekingResult.Messages);

            var result = await _organizationService.UpdateOrganizationInfo(request, id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

        // DELETE api/<OrganizationsController>/5
        [HttpDelete("DeleteOrg/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteOrg(int id)
        {
            var result = await _organizationService.Delete(id);

            if (!result.Succeeded)
                return BadRequest(result.Messages);

            return Ok(result);
        }

       
    }
}
