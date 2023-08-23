using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public interface IFormSectionService
    {
        Task<Result<string>> AddFormSection(FormSectionRequest section);
        Task<Result<string>> EditFormSection(FormSectionRequest section, int id);
        Task<Result<string>> DeleteFormSection(int id);
        Task<Result<FormSectionResponse>> GetFormSectionById(int id);   
        Task<Result<IEnumerable<FormSectionResponse>>> GetAllFormSectionsByQuestionBlockId(int questionBlockId);
    }
}
