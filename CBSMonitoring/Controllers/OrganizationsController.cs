﻿using CBSMonitoring.Constants;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CBSMonitoring.DTOs.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequirePasswordChange")]
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

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetAllWithShortInfo")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetAllWithShortInfo()
        {
            var result = await _organizationService.GetAllOrganizationsInShort();

            return StatusCode(result.StatusCode, result);
        }

        // GET api/<OrganizationsController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _organizationService.GetOrganizationById(id);

            return StatusCode(result.StatusCode, result);
        }

        // POST api/<OrganizationsController>
        [HttpPost("AddOrganization")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddOrganization([FromBody] OrganizationRequest request)
        {
            var result = await _organizationService.AddOrganization(request);

            return StatusCode(result.StatusCode, result);
        }

        // PUT api/<OrganizationsController>/5
        [HttpPut("UpdateOrgInfo/{id}")]
        public async Task<IActionResult> UpdateOrgInfo(int id, [FromBody] OrganizationRequest request)
        {
            var result = await _organizationService.UpdateOrganizationInfo(request, id);

            return StatusCode(result.StatusCode, result);
        }

        // DELETE api/<OrganizationsController>/5
        [HttpDelete("DeleteOrg/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteOrg(int id)
        {
            var result = await _organizationService.Delete(id);

            return StatusCode(result.StatusCode, result);
        }

       
    }
}
