using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using CBSMonitoring.Models.Forms;
using ERPBlazor.Shared.Wrappers;
using System.Reflection;
using CBSMonitoring.Constants;
using CBSMonitoring.Model;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Result<string>> AddMonitoringReport<T>(MonitoringDto reportForm, string sectionNumber, IFormCollection? fileItems = null)
            where T : OrgMonitoring
        {
            
            try
            {
                T report = _mapper.Map<T>(reportForm);
                Type type = report.GetType();

                report.CreatedDateTime = DateTime.Now;
                report.SectionNumber = sectionNumber;

                var result = await GetFilledEntity<OrgMonitoring>(sectionNumber, report, fileItems);

                await _genericRepository.AddAsync(result.Data);

                //if (fileItems is not null)
                //{
                //    return await Result<string>.SuccessAsync($"No file uploaded to form 1.1.1 report with id ={type.GetProperty("MonitoringId")?.GetValue(report, null)}");
                //}

                //PropertyInfo monitoringIdProp = type.GetProperty(nameof(OrgMonitoring.MonitoringId))!;
                //int monitoringId = Convert.ToInt32(monitoringIdProp.GetValue(report));
                //var result = await _fileWorkRoom.SaveFile(reportForm.FileItem, monitoringId);

                //PropertyInfo fileId = GetFileIdProperty(type);
                //fileId.SetValue(report, result.Data);

                //await _genericRepository.UpdateAsync(report);
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
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");

        }

        public async Task<Result<string>> EditMonitoringReport<T>(MonitoringDto reportForm, int id)
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

        public async Task<Result<object>> GetQuarterReport<T, TDto>(ReportRequest reportRequest)
            where T : OrgMonitoring
            where TDto : class
        {
            var year = DateTime.Now.Year;
            var quarter = (DateTime.Now.Month - 1) / 3 + 1;

            if (reportRequest.Year != 0)
            {
                year = reportRequest.Year;
                quarter = reportRequest.Quarter;
            }

            var report = await _genericRepository.GetByParameterAsync<T>(e => e.Year == year && e.QuarterIndex == quarter, 
                                                                            query => query.Include(e => e.Organization));

            if (report == null)
                return await Result<object>.FailAsync($"Current quarter report with section number ={reportRequest.SectionNumber} not found!");

            var monitoringDto = _mapper.Map<TDto>(report);

            return await Result<object>.SuccessAsync(monitoringDto);
        }

        private static PropertyInfo GetFileIdProperty(Type type)
        {
            if (type == typeof(Form1_1_1))
                return type.GetProperty(nameof(Form1_1_1.File_1_1_1Id))!;

            if (type == typeof(Form1_1_2))
                return type.GetProperty(nameof(Form1_1_2.File_1_1_2Id))!;

            if (type == typeof(Form2_2_1))
                return type.GetProperty(nameof(Form2_2_1.File_2_2_1Id))!;

            else
                throw new NotSupportedException($"{type.Name} form doesn't have file property.");
        }

        private async Task<Result<OrgMonitoring>> GetFilledEntity<T>(string sectionNumber, T report, IFormCollection? fileItems = null)
        where T : OrgMonitoring
        {
            var Organization = await _genericRepository.GetByIdAsync<Organization>(report.OrganizationId) 
                               ?? throw new NullReferenceException($"with id={report.OrganizationId} organization not found!");
            
            OrgMonitoringDto Dto = new(Organization.OrganizationName, report.Year, report.QuarterIndex, report.SectionNumber);

            if (report.GetType() == typeof(Form2_8_1))
            {
                PropertyInfo qualificationImprovedEmployeeListProperty =
                    report.GetType().GetProperty(nameof(Form2_8_1.QualificationImprovedEmployees))!;
                List<QualificationImprovedEmployee> qualificationImprovedEmployees = (List<QualificationImprovedEmployee>)
                    qualificationImprovedEmployeeListProperty.GetValue(report)!;

                if (fileItems is null)
                {
                    throw new NotSupportedException($"No files received.");
                }

                List<FileModel> FileModelList = new();

                foreach (var file in fileItems.Files)
                {
                    var fileItem = new FileItem(file);
                    var result = await _fileWorkRoom.SaveFile(fileItem, Dto);

                    FileModelList.Add(result.Data);
                }

                for (int i = 0; i < Math.Min(qualificationImprovedEmployees.Count, FileModelList.Count); i++)
                {
                    qualificationImprovedEmployees[i].Certificate = FileModelList[i];
                }

                qualificationImprovedEmployeeListProperty.SetValue(report, qualificationImprovedEmployees);

                
            }

            if (report.GetType() == typeof(Form1_1_1))
            {
                PropertyInfo FileModelProperty = report.GetType().GetProperty(nameof(Form1_1_1.FileModel))!;

                foreach (var file in fileItems.Files)
                {
                    var fileItem = new FileItem(file);
                    var result = await _fileWorkRoom.SaveFile(fileItem, Dto);

                    FileModelProperty.SetValue(report, result.Data);

                    break;
                }
            }

            if (report.GetType() == typeof(Form1_1_2))
            {
                PropertyInfo FileModelProperty = report.GetType().GetProperty(nameof(Form1_1_2.FileModel))!;

                foreach (var file in fileItems.Files)
                {
                    var fileItem = new FileItem(file);
                    var result = await _fileWorkRoom.SaveFile(fileItem, Dto);

                    FileModelProperty.SetValue(report, result.Data);

                    break;
                }

            }

            return await Result<OrgMonitoring>.SuccessAsync(report);
        }

    }
}
