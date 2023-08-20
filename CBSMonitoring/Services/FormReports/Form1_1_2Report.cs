using CBSMonitoring.DTOs;
using CBSMonitoring.Models.Forms;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services.FormReports
{
    public class Form1_1_2Report : IMonitoringFactory
    {
        private readonly IGenericRepository<Form1_1_2> _genericRepository;
        private readonly IFileWorkRoom _fileWorkRoom;
        public Form1_1_2Report(IGenericRepository<Form1_1_2> generic, IFileWorkRoom fileWorkRoom)
        {
            _fileWorkRoom = fileWorkRoom;
            _genericRepository = generic;
        }
        public async Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm)
        {
            Form1_1_2 report = new()
            {
               IsReviewedByCBS = reportForm.IsReviewedByCBS
            };

            try
            {
                await _genericRepository.Add(report);

                if (reportForm.Files is null || !reportForm.Files.Any())
                {
                    return await Result<string>.SuccessAsync($"No file uploaded to form 1.1.1 report with id ={report.MonitoringId}");
                }

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

        public async Task<Result<string>> DeleteMonitoringReport(int id)
        {
            var report = await _genericRepository.GetById(id);
            if (report == null)
                return await Result<string>.FailAsync($"Report with id={id} not found!");
            try
            {
                await _genericRepository.Delete(report);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
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
