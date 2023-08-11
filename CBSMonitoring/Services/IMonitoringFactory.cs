using CBSMonitoring.DTOs;
using CBSMonitoring.Models;

namespace CBSMonitoring.Services
{
    public interface IMonitoringFactory
    {
        Task AddMonitoringReport(MonitoringDTO reportForm);
        Task EditMonitoringReport(MonitoringDTO reportForm);
        Task GetMonitoringReport(int id);
        Task DeleteMonitoringReport(int id);

    }
}
