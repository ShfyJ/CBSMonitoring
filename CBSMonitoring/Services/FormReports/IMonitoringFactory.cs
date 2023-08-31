﻿using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Services.FormReports
{
    public interface IMonitoringFactory
    {
        Task<Result<string>> AddMonitoringReport<T>(MonitoringDto reportForm, string sectionNumber) where T : OrgMonitoring;
        Task<Result<string>> EditMonitoringReport<T>(MonitoringDto reportForm, int id) where T : OrgMonitoring;
        Task<Result<object>> GetQuarterReport<T, TDto>(ReportRequest reportRequest) where T : OrgMonitoring where TDto : class;
        Task<Result<string>> DeleteMonitoringReport<T>(int id) where T : OrgMonitoring;


    }
}
