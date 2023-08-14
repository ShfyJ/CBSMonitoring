using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public class Form1_1Report : IMonitoringFactory
    {

        private readonly AppDbContext _context;
        private readonly IFileWorkRoom _fileWorkRoom;
        public Form1_1Report(AppDbContext context, IFileWorkRoom fileWorkRoom)
        {
            _context = context;
            _fileWorkRoom = fileWorkRoom;
        }

        public async Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm)
        {
           //throw new NotImplementedException();

            Form1_1 report = new()
            {
                HasPolicy = reportForm.HasPolicy,
                IsReviewedByCBS = reportForm.IsReviewedByCBS,
                AgreedWithAuthBody = reportForm.AgreedWithAuthBody,
                NumberOfEmployees = reportForm.NumberOfEmployees,
                PercentageOfEmpFamiliarWithPolicy = reportForm.PercentageOfEmpFamiliarWithPolicy,
                IsAuditConducted = reportForm.IsAuditConducted,
                HasISPRevised = reportForm.HasISPRevised,
                NumberOfRevision = reportForm.NumberOfRevision,
                YearOfRevisions = reportForm.YearOfRevisions,
            };

            try
            {
                await _context.AddAsync(report);
                await _context.SaveChangesAsync();

                foreach (var item in reportForm.Files)
                {
                    await _fileWorkRoom.SaveFile(item, report.MonitoringId);
                }
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
            var report = await _context.Form1_1s.FindAsync(id);

            if (report == null)
                return await Result<string>.FailAsync($"Report with id={id} not found");

            report.HasPolicy = reportForm.HasPolicy;
            report.IsReviewedByCBS = reportForm.IsReviewedByCBS;
            report.AgreedWithAuthBody = reportForm.AgreedWithAuthBody;
            report.NumberOfEmployees = reportForm.NumberOfEmployees;
            report.PercentageOfEmpFamiliarWithPolicy = reportForm.PercentageOfEmpFamiliarWithPolicy;
            report.IsAuditConducted = reportForm.IsAuditConducted;
            report.HasISPRevised = reportForm.HasISPRevised;
            report.NumberOfRevision = reportForm.NumberOfRevision;
            report.YearOfRevisions = reportForm.YearOfRevisions;

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
