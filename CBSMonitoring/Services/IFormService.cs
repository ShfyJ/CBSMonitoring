using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public interface IFormService
    {
        Task<Result<string>> AddForm(MonitoringFormDTO form);
        Task<Result<string>> EditForm(MonitoringForm form);
        Task<Result<string>> DeleteForm(int id);
        Task<Result<MonitoringForm>> GetForm(int id);   
        Task<Result<IEnumerable<MonitoringForm>>> GetAllForm();
    }
}
