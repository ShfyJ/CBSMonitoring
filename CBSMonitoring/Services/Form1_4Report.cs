using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace CBSMonitoring.Services
{
    public class Form1_4Report : IMonitoringFactory
    {
        private readonly AppDbContext _context;
        public Form1_4Report(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm)
        {
            Form1_4 report = new()
            {
                IsListAvailable = reportForm.IsListAvailable,
                ConfidentialDocNumber = reportForm.ConfidentialDocNumber,
                ConfidentialDocDate = reportForm.ConfidentialDocDate,
                IsComissionPresent = reportForm.IsComissionPresent,
                ComissionDocNumber = reportForm.ComissionDocNumber,
                ComissionDocDate = reportForm.ComissionDocDate,
                IsListOfOfficialAvailable = reportForm.IsListOfOfficialAvailable,
                OfficialsDocNumber = reportForm.OfficialsDocNumber,
                OfficialsDocDate = reportForm.OfficialsDocDate,
                IsListCommToEmps = reportForm.IsListCommToEmps
            };

            try
            {
                await _context.AddAsync(report);
                await _context.SaveChangesAsync();

            }

            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }


            return await Result<string>.SuccessAsync($"Success");
        }

        public Task<Result<string>> DeleteMonitoringReport(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<string>> EditMonitoringReport(MonitoringDTO reportForm, int id)
        {
            var report = await _context.Form1_4s.FindAsync(id);

            if (report == null)
                return await Result<string>.FailAsync($"Report with id={id} not found");

            report.IsListAvailable = reportForm.IsListAvailable;
            report.ConfidentialDocNumber = reportForm.ConfidentialDocNumber;
            report.ConfidentialDocDate = reportForm.ConfidentialDocDate;
            report.IsComissionPresent = reportForm.IsComissionPresent;
            report.ComissionDocNumber = reportForm.ComissionDocNumber;
            report.ComissionDocDate = reportForm.ComissionDocDate;
            report.IsListOfOfficialAvailable = reportForm.IsListOfOfficialAvailable;
            report.OfficialsDocNumber = reportForm.OfficialsDocNumber;
            report.OfficialsDocDate = reportForm.OfficialsDocDate;
            report.IsListCommToEmps = reportForm.IsListCommToEmps;

            try
            {
                _context.Update(report);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }

        public Task<Result<MonitoringDTO>> GetMonitoringReport(int id)
        {
            throw new NotImplementedException();
        }
    }
}
