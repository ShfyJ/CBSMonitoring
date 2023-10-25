using CBSMonitoring.DTOs;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IOrganizationService
    {
        Task<Result<string>> AddOrganization(OrganizationRequest request);
        Task<Result<OrganizationResponse>> GetOrganizationById(int id);
        Task<Result<IEnumerable<OrganizationResponse>>> GetAllOrganizations();
        Task<Result<IEnumerable<OrgShortInfoResponse>>> GetAllOrganizationsInShort();
        Task<Result<string>> UpdateOrganizationInfo(OrganizationRequest request, int id);
        Task<Result<string>> Delete(int id);
    }
}
