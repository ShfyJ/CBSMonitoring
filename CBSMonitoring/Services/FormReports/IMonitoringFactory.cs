using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Services.FormReports
{
    public interface IMonitoringFactory
    {
        Task<Result<string>> AddMonitoringReport<T>(MonitoringDTO reportForm, string sectionNumber) where T : OrgMonitoring;
        Task<Result<string>> EditMonitoringReport<T>(MonitoringDTO reportForm, int id) where T : OrgMonitoring;
        Task<Result<object>> GetQuaterReport<T, TDto>(ReportRequest reportRequest) where T : OrgMonitoring where TDto : class;
        Task<Result<string>> DeleteMonitoringReport<T>(int id) where T : OrgMonitoring;
        

    }
}
