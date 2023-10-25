using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IAuthService
    {
        Task<Result<string>> Registeration(RegistrationRequest request);
        Task<Result<LoginResponse>> Login(LoginRequest request);
        Task<Result<UpdatePasswordResponse>> UpdatePassword(UpdatePasswordRequest request);
    }
}
