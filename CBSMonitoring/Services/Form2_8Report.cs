﻿using CBSMonitoring.DTOs;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public class Form2_8Report : IMonitoringFactory
    {
        public Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> DeleteMonitoringReport(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> EditMonitoringReport(MonitoringDTO reportForm, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<MonitoringDTO>> GetMonitoringReport(int id)
        {
            throw new NotImplementedException();
        }
    }
}
