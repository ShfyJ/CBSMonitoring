using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using CBSMonitoring.Models.Forms;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services.FormReports
{
    public class Form1_1_1Report : IMonitoringFactory
    {

        private readonly IGenericRepository<Form1_1_1> _genericRepository;
        private readonly IFileWorkRoom _fileWorkRoom;
        public Form1_1_1Report(IGenericRepository<Form1_1_1> genericRepository, IFileWorkRoom fileWorkRoom)
        {
            _genericRepository = genericRepository;
            _fileWorkRoom = fileWorkRoom;
        }

        public async Task<Result<string>> AddMonitoringReport(MonitoringDTO reportForm)
        {
            //throw new NotImplementedException();

            Form1_1_1 report = new()
            {
                HasPolicy = reportForm.HasPolicy                              
            };

            try
            {
                await _genericRepository.Add(report);

                if(reportForm.Files is null || !reportForm.Files.Any()) 
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
            catch(Exception ex)
            {
                return await Result<string>.FailAsync( ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");

        }

        public async Task<Result<string>> EditMonitoringReport(MonitoringDTO reportForm, int id)
        {
            var report = await _genericRepository.GetById(id);

            if (report == null)
                return await Result<string>.FailAsync($"Report with id={id} not found");

            report.HasPolicy = reportForm.HasPolicy;
            try
            {
                await _genericRepository.Update(report);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");

        }

        public async Task<Result<MonitoringDTO>> GetMonitoringReport(int id)
        {
            var report = await _genericRepository.GetById(id);

            if (report == null)
                return await Result<MonitoringDTO>.FailAsync($"Report with id={id} not found!");

            MonitoringDTO monitoringDTO = new()
            {
                OrganizationId = report.OrganizationId,
                QuaterIndex = report.QuaterIndex,
                Year = report.Year,
                HasPolicy = report.HasPolicy,
                FileId = report.File_1_1_1Id,
            };

            return await Result<MonitoringDTO>.SuccessAsync(monitoringDTO);
        }
    }
}
