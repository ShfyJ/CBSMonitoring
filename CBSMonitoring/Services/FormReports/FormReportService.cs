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
using CBSMonitoring.DTOs.FormDtos;

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

                report.CreatedDateTime = DateTime.Now;
                report.SectionNumber = sectionNumber;

                var result = await GetFilledEntity(report, fileItems);

                var entity = await _genericRepository.GetFirstByParameterAsync<T>(e => e.SectionNumber == sectionNumber
                                                        && e.Year == report.Year && e.QuarterIndex == report.QuarterIndex
                                                        && e.OrganizationId == report.OrganizationId);

                if (entity is null)
                {

                    await _genericRepository.AddAsync(result.Data);
                }

                else
                {
                    await ReplaceExistingEntityWithNewOne<T>(result.Data, entity);
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
            OrgMonitoring? report = reportRequest.SectionNumber switch
            {
                FormType.Form1_1_1 => await _genericRepository.GetFirstByParameterAsync<Form1_1_1>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form1_1_2 => await _genericRepository.GetFirstByParameterAsync<Form1_1_2>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form1_1_3 => await _genericRepository.GetFirstByParameterAsync<Form1_1_3>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_1_1 => await _genericRepository.GetFirstByParameterAsync<Form2_1_1>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_1_2 => await _genericRepository.GetFirstByParameterAsync<Form2_1_2>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_2_1 => await _genericRepository.GetFirstByParameterAsync<Form2_2_1>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_2_2 => await _genericRepository.GetFirstByParameterAsync<Form2_2_2>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.TimelyExecutionOfPlans).Include(e => e.FileModels)),
                FormType.Form2_3_1 => await _genericRepository.GetFirstByParameterAsync<Form2_3_1>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_3_2 => await _genericRepository.GetFirstByParameterAsync<Form2_3_2>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_8_1 => await _genericRepository.GetFirstByParameterAsync<Form2_8_1>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.QualificationImprovedEmployees)),
                _ => await _genericRepository.GetFirstByParameterAsync<T>(e => e.Year == reportRequest.Year && e.QuarterIndex == reportRequest.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization)),
            };

            if (report == null)
                return await Result<object>.FailAsync($"Current quarter report with section number = {reportRequest.SectionNumber} " +
                                                        $"and organization Id = {reportRequest.OrganizationId} not found!");

            var monitoringDto = _mapper.Map<TDto>(report);

            return await Result<object>.SuccessAsync(monitoringDto);
        }

        private async Task<Result<OrgMonitoring>> GetFilledEntity<T>(T report, IFormCollection? fileItems = null)
        where T : OrgMonitoring
        {
            var Organization = await _genericRepository.GetByIdAsync<Organization>(report.OrganizationId) 
                               ?? throw new NullReferenceException($"with id={report.OrganizationId} organization not found!");
            
            OrgMonitoringDto Dto = new(Organization.FullName, report.Year, report.QuarterIndex, report.SectionNumber);

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

        private async Task ReplaceExistingEntityWithNewOne<T>(OrgMonitoring newEntity, T entity)
            where T : OrgMonitoring
        {
            object? oldEntity = null;
            int oldEntityId = entity.MonitoringId;
            switch(newEntity)
            {
                case Form1_1_1:
                    
                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form1_1_1>(e => e.MonitoringId == oldEntityId, 
                                                                               query => query.Include(e => e.FileModel));
                    break;

                case Form1_1_2:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form1_1_2>(e => e.MonitoringId == oldEntityId,
                                                                               query => query.Include(e => e.FileModel));

                    break;

                case Form1_1_3:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form1_1_3>(e => e.MonitoringId == oldEntityId,
                                                                               query => query.Include(e => e.FileModel));

                    break;

                case Form2_1_1:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form2_1_1>(e => e.MonitoringId == oldEntityId,
                                                                               query => query.Include(e => e.FileModel));

                    break;

                case Form2_1_2:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form2_1_2>(e => e.MonitoringId == oldEntityId,
                                                                               query => query.Include(e => e.FileModel));

                    break;

                case Form2_2_1:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form2_2_1>(e => e.MonitoringId == oldEntityId,
                                                                               query => query.Include(e => e.FileModel));

                    break;

                case Form2_2_2:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form2_2_2>(e => e.MonitoringId == oldEntityId,
                                                                                query => query.Include(e => e.TimelyExecutionOfPlans));

                    break;

                case Form2_3_1:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form2_3_1>(e => e.MonitoringId == oldEntityId,
                                                                               query => query.Include(e => e.FileModel));

                    break;

                case Form2_3_2:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form2_3_2>(e => e.MonitoringId == oldEntityId,
                                                                               query => query.Include(e => e.FileModel));

                    break;

                case Form2_8_1:

                    oldEntity = await _genericRepository.GetFirstByParameterAsync<Form2_8_1>(e => e.MonitoringId == oldEntityId,
                                                                                query => query.Include(e => e.QualificationImprovedEmployees)
                                                                                .ThenInclude(q => q.Certificate));

                    break;

                default:

                    oldEntity = entity;

                    break;

            }

            if (oldEntity == null)
            {
                await _genericRepository.AddAsync(newEntity);
                return;
            }

            _mapper.Map(newEntity, oldEntity);

            await _genericRepository.UpdateAsync(oldEntity);
        }
    }
}
