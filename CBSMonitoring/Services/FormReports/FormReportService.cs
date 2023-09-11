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

                var result = await GetFilledEntity<OrgMonitoring>(report, fileItems);

                await _genericRepository.AddAsync(result.Data);

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

        private async Task<Result<OrgMonitoring>> GetFilledEntity<T>(T report, IFormCollection? fileItems = null)
        where T : OrgMonitoring
        {
            var Organization = await _genericRepository.GetByIdAsync<Organization>(report.OrganizationId) 
                               ?? throw new NullReferenceException($"with id={report.OrganizationId} organization not found!");
            
            OrgMonitoringDto Dto = new(Organization.OrganizationName, report.Year, report.QuarterIndex, report.SectionNumber);

            var fileModels = await ProcessMultipleFiles(fileItems, Dto);

            PropertyInfo fileModelProperty;

            switch (report)
            {
                case Form1_1_1:

                    fileModelProperty = report.GetType().GetProperty(nameof(Form1_1_1.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form1_1_2:
                    
                    fileModelProperty = report.GetType().GetProperty(nameof(Form1_1_2.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form1_1_3:

                    fileModelProperty = report.GetType().GetProperty(nameof(Form1_1_3.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_1_1:

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_1_1.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_1_2:

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_1_2.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_2_1:

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_2_1.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;
                case Form2_2_2:

                    PropertyInfo relatedFiles =
                    report.GetType().GetProperty(nameof(Form2_2_2.FileModels))!;
                    
                    relatedFiles.SetValue(report, fileModels);
                    break;

                case Form2_3_1:

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_3_1.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_3_2:

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_3_2.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_8_1:

                    PropertyInfo qualificationImprovedEmployeeListProperty =
                    report.GetType().GetProperty(nameof(Form2_8_1.QualificationImprovedEmployees))!;
                    List<QualificationImprovedEmployee> qualificationImprovedEmployees = (List<QualificationImprovedEmployee>)
                        qualificationImprovedEmployeeListProperty.GetValue(report)!;

                    for (int i = 0; i < Math.Min(qualificationImprovedEmployees.Count, fileModels.Count); i++)
                    {
                        qualificationImprovedEmployees[i].Certificate = fileModels[i];
                    }

                    qualificationImprovedEmployeeListProperty.SetValue(report, qualificationImprovedEmployees);
                    break;

            }

            return await Result<OrgMonitoring>.SuccessAsync(report);
        }

        private async Task<List<FileModel>> ProcessMultipleFiles(IFormCollection? fileItems, OrgMonitoringDto dto)
        {
            if (fileItems is null)
            {
                throw new NotSupportedException($"No files received.");
            }

            List<FileModel> fileModels = new();

            foreach (var file in fileItems.Files)
            {
                var fileItem = new FileItem(file);
                var result = await _fileWorkRoom.SaveFile(fileItem, dto);

                fileModels.Add(result.Data);
            }

            return fileModels;
        }
    }
}
