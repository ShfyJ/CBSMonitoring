using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public class Form1_3Report : IMonitoringFactory
    {
        private readonly AppDbContext _context;
        public Form1_3Report(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm)
        {
            Form1_3 report = new()
            {
                NumberOfRegJournal = reportForm.NumberOfRegJournal,
                ListOfRegJournal = reportForm.ListOfRegJournal,
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
            var report = await _context.Form1_3s.FindAsync(id);

            if (report == null)
                return await Result<string>.FailAsync($"Report with id={id} not found");

            report.NumberOfRegJournal = reportForm.NumberOfRegJournal;
            report.ListOfRegJournal = reportForm.ListOfRegJournal;

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
