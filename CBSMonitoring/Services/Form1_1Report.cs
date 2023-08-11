using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;

namespace CBSMonitoring.Services
{
    public class Form1_1Report : IMonitoringFactory
    {

        private AppDbContext _context;
        public Form1_1Report(AppDbContext context)
        {
            _context = context;
        }

        public Task AddMonitoringReport(MonitoringDTO reportForm)
        {
           // throw new NotImplementedException();

            Form1_1 report = new()
            {
                HasPolicy = reportForm.HasPolicy,
                IsReviewedByCBS = reportForm.IsReviewedByCBS,
                NumberOfEmployees = reportForm.NumberOfEmployees,
                PercentageOfEmpFamiliarWithPolicy = reportForm.PercentageOfEmpFamiliarWithPolicy,
                IsAuditConducted = reportForm.IsAuditConducted,
                HasISPRevised = reportForm.HasISPRevised,
                NumberOfRevision = reportForm.NumberOfRevision,
                YearOfRevisions = reportForm.YearOfRevisions,
            };

            _context.Add(report);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task DeleteMonitoringReport(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditMonitoringReport(MonitoringDTO reportForm)
        {
            throw new NotImplementedException();
        }

        public Task GetMonitoringReport(int id)
        {
            throw new NotImplementedException();
        }
    }
}
