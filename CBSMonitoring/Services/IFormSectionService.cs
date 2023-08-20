using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public interface IFormSectionService
    {
        Task<Result<string>> AddFormSection(FormSectionInDTO section);
        Task<Result<string>> EditFormSection(FormSectionInDTO section, int id);
        Task<Result<string>> DeleteFormSection(int id);
        Task<Result<FormSectionOutDTO>> GetFormSectionById(int id);   
        Task<Result<IEnumerable<FormSectionOutDTO>>> GetAllFormSectionsByQuestionBlockId(int questionBlockId);
    }
}
