using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services.FormReports
{
    public interface IMonitoringFactory
    {
        Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm);
        Task<Result<string>> EditMonitoringReport(MonitoringDTO reportForm, int id);
        Task<Result<MonitoringDTO>> GetMonitoringReport(int id);
        Task<Result<string>> DeleteMonitoringReport(int id);

    }
}
