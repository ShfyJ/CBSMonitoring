using AutoMapper;
using AutoMapper.Configuration.Conventions;
using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.DTOs.FormDtos;
using CBSMonitoring.Models;
using CBSMonitoring.Models.Forms;
using ERPBlazor.Shared.Wrappers;
using System.Reflection;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Services.FormReports
{
    public class FormReportService : IMonitoringFactory
    {

        private readonly IGenericRepository _genericRepository;
        private readonly IFileWorkRoom _fileWorkRoom;
        private readonly IMapper _mapper;
        public FormReportService(IGenericRepository genericRepository, 
            IFileWorkRoom fileWorkRoom, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _fileWorkRoom = fileWorkRoom;
            _mapper = mapper;
        }

        public async Task<Result<string>> AddMonitoringReport<T>(MonitoringDTO reportForm, string sectionNumber)
            where T : OrgMonitoring
        {
            T report = _mapper.Map<T>(reportForm);
            Type type = report.GetType();

            PropertyInfo CreatedDateTime = type.GetProperty(nameof(OrgMonitoring.CreatedDateTime))!;
            CreatedDateTime.SetValue(report, DateTime.Now);

            PropertyInfo SectionNumber = type.GetProperty(nameof(OrgMonitoring.SectionNumber))!;
            SectionNumber.SetValue(report, sectionNumber);

            try
            {
                await _genericRepository.AddAsync(report);

                if (reportForm.Files is null || !reportForm.Files.Any())
                {
                    return await Result<string>.SuccessAsync($"No file uploaded to form 1.1.1 report with id ={type.GetProperty("MonitoringId")?.GetValue(report, null)}");
                }

                foreach (var item in reportForm.Files)
                {
                    PropertyInfo monitoringIdProp = type.GetProperty(nameof(OrgMonitoring.MonitoringId))!;
                    int monitoringId = Convert.ToInt32(monitoringIdProp.GetValue(report));
                    await _fileWorkRoom.SaveFile(item, monitoringId);
                }
            }

            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }


            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<string>> DeleteMonitoringReport<T>(int id)
            where T : OrgMonitoring
        {
            var report = await _genericRepository.GetByIdAsync<T>(id);
            if (report == null)
                return await Result<string>.FailAsync($"Report with id={id} not found!");
            try
            {
                await _genericRepository.DeleteAsync(report);
            }
            catch(Exception ex)
            {
                return await Result<string>.FailAsync( ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");

        }

        public async Task<Result<string>> EditMonitoringReport<T>(MonitoringDTO reportForm, int id)
            where T : OrgMonitoring
        {
            var report = await _genericRepository.GetByIdAsync<T>(id);

            if (report == null)
                return await Result<string>.FailAsync($"Report with id={id} not found");

            _mapper.Map(reportForm, report);

            try
            {
                await _genericRepository.UpdateAsync(report);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");

        }

        public async Task<Result<object>> GetQuaterReport<T, TDto>(ReportRequest reportRequest)
            where T : OrgMonitoring
            where TDto : class
        {
            int year = DateTime.Now.Year;
            int quater = (DateTime.Now.Month - 1) / 3 + 1;
            
            if (reportRequest.year != 0)
            {
                year = reportRequest.year;
                quater = reportRequest.quater;
            }

            var report = await _genericRepository.GetByParameterAsync<T>(e => e.Year == year && e.QuaterIndex == quater);

            if (report == null)
                return await Result<object>.FailAsync($"Current quater report with section number ={reportRequest.sectionNumber} not found!");

            var monitoringDTO = _mapper.Map<TDto>(report);

            return await Result<object>.SuccessAsync(monitoringDTO);
        }

    }
}
