using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.Model;
using ERPBlazor.Shared.Wrappers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IGenericRepository _orgRepository;
        private readonly IMapper _mapper;
        public OrganizationService(IGenericRepository orgRepository, IMapper mapper)
        {
            _orgRepository = orgRepository;
            _mapper = mapper;
        }
        public async Task<Result<string>> AddOrganization(OrganizationRequest request)
        {
            try
            {
                await _orgRepository.AddAsync(_mapper.Map<Organization>(request));
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Неуспешно: {ex.Message}");
            }

            return await Result<string>.SuccessAsync($"Успешно!");
        }

        public async Task<Result<string>> Delete(int id)
        {
            var organization = await _orgRepository.GetByIdAsync<Organization>(id);
            if(organization == null)
            {
                return await Result<string>.FailAsync($"Организация с id={id} недоступна!");
            }

            try
            {
                await _orgRepository.DeleteAsync(organization);
            }
            catch(Exception ex)
            {
                return await Result<string>.FailAsync( $"Неуспешно: {ex.Message}");
            }

            return await Result<string>.SuccessAsync($"Успешно!");
        }

        public async Task<Result<IEnumerable<OrganizationResponse>>> GetAllOrganizations()
        {
           var organizations = await _orgRepository.GetAllAsync<Organization>();

           return await Result<IEnumerable<OrganizationResponse>>.SuccessAsync(_mapper.Map<IEnumerable<OrganizationResponse>>(organizations));
        }

        public async Task<Result<IEnumerable<OrgShortInfoResponse>>> GetAllOrganizationsInShort()
        {
            var organizations = await _orgRepository.SelectAllAsync<Organization, OrgShortInfoResponse>(e => new OrgShortInfoResponse( e.OrganizationId, e.FullName ));
            
            return await Result<IEnumerable<OrgShortInfoResponse>>.SuccessAsync(organizations);
        }

        public async Task<Result<OrganizationResponse>> GetOrganizationById(int id)
        {
            var organization = await _orgRepository.GetByIdAsync<Organization>(id);

            if (organization == null)
                return await Result<OrganizationResponse>.FailAsync($"Организация с id={id} недоступна!");

            return await Result<OrganizationResponse>.SuccessAsync(_mapper.Map<OrganizationResponse>(organization));
        }

        public async Task<Result<string>> UpdateOrganizationInfo(OrganizationRequest request, int id)
        {
            var organization = await _orgRepository.GetByIdAsync<Organization>(id);
            if (organization == null)
                return await Result<string>.FailAsync($"Организация с id={id} недоступна!");

            try
            {
                await _orgRepository.UpdateAsync(_mapper.Map(request, organization));
            }
            catch(Exception ex)
            {
                return await Result<string>.FailAsync($"Неуспешно: {ex.Message}");
            }

            return await Result<string>.SuccessAsync($"Успешно!");
        }
    }
}
