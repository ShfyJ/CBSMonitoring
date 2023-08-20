using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services.FormReports
{
    public class Form1_2Report : IMonitoringFactory
    {
        private readonly AppDbContext _context;
        public Form1_2Report(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm)
        {
            throw new NotImplementedException();
            //Form1_2_1 report = new()
            //{
            //    NumberOfRegDocs = reportForm.NumberOfRegDocs,
            //    ListOfRegDocs = reportForm.ListOfRegDocs,
            //};

            try
            {
               // await _context.AddAsync(report);
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
            throw new NotImplementedException();
           // var report = await _context.Form1_2s.FindAsync(id);

            //if (report == null)
            //    return await Result<string>.FailAsync($"Report with id={id} not found");

            //report.NumberOfRegDocs = reportForm.NumberOfRegDocs;
            //report.ListOfRegDocs = reportForm.ListOfRegDocs;

            try
            {
               // _context.Update(report);
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
