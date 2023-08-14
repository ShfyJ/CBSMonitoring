using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace CBSMonitoring.Services
{
    public class Form1_5Report : IMonitoringFactory
    {
        private readonly AppDbContext _context;
        public Form1_5Report(AppDbContext context)
        {
           _context = context;
        }
        public async Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm)
        {
            Form1_5 report = new()
            {
                IsAgreementsAvailable = reportForm.IsAgreementsAvailable,
                IsRelevantClausesAvailable = reportForm.IsRelevantClausesAvailable,
                NumberOfEmplFamWithAgreements = reportForm.NumberOfEmplFamWithAgreements,
                PercentageOfEmpFamWithAgreements = reportForm.PercentageOfEmpFamWithAgreements,               
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
            var report = await _context.Form1_5s.FindAsync(id);

            if (report == null)
                return await Result<string>.FailAsync($"Report with id={id} not found");

            report.IsAgreementsAvailable = reportForm.IsAgreementsAvailable;
            report.IsRelevantClausesAvailable = reportForm.IsRelevantClausesAvailable;
            report.NumberOfEmplFamWithAgreements = reportForm.NumberOfEmplFamWithAgreements;
            report.PercentageOfEmpFamWithAgreements = reportForm.PercentageOfEmpFamWithAgreements;
            

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
