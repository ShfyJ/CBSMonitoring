using ERPBlazor.Shared.Wrappers;
using Microsoft.Extensions.Caching.Memory;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IAuthService
    {
        Task<Result<RegistrationResponse>> Registeration(RegistrationRequest request);
        Task<Result<AuthResponse>> Login(LoginRequest request, IMemoryCache memoryCache);
        Task<Result<AuthResponse>> Logout(string token);
        Task<Result<string>> SendOtpEmail(string username, string tempToken);
        Task<Result<AuthResponse>> VerifyOtp(OtpVerificationRequest otpVerificationRequest);        
        Task<Result<UpdatePasswordResponse>> UpdatePassword(UpdatePasswordRequest request);
    }
}
