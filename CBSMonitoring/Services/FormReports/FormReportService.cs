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
using CBSMonitoring.Webframework;
using System.Text.Json;
using Newtonsoft.Json;
using static CBSMonitoring.DTOs.Responses;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using AutoMapper.Configuration.Annotations;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using CBSMonitoring.DTOs.BlockDtos;

namespace CBSMonitoring.Services.FormReports
{
    public class FormReportService : IMonitoringFactory
    {

        private readonly IGenericRepository _genericRepository;
        private readonly IFileWorkRoom _fileWorkRoom;
        private readonly IMapper _mapper;
        private readonly FormFactory _formFactory;
        public FormReportService(IGenericRepository genericRepository,
            IFileWorkRoom fileWorkRoom, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _fileWorkRoom = fileWorkRoom;
            _mapper = mapper;
            _formFactory = new ConcreteFormFactory();
        }

        public async Task<Result<string>> AddMonitoringReport<T>(MonitoringDto reportForm, string sectionNumber, IFormCollection? fileItems = null)
            where T : OrgMonitoring
        {
            
            try
            {
                T report = _mapper.Map<T>(reportForm);

                report.CreatedDateTime = DateTime.Now;
                report.SectionNumber = sectionNumber;

                var result = await GetFilledEntity(report, new DocInfo(reportForm.DocNumber,reportForm.DocDate), fileItems);

                var entity = await _genericRepository.GetFirstByParameterAsync<T>(e => e.SectionNumber == sectionNumber
                                                        && e.Year == report.Year && e.QuarterIndex == report.QuarterIndex
                                                        && e.OrganizationId == report.OrganizationId);

                if (entity is null)
                {

                    await _genericRepository.AddAsync(result.Data);
                }

                else
                {
                    await ReplaceExistingEntityWithNewOne(result.Data, entity);
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

            var sectionNumber = monitoringDto.GetType().GetProperty(nameof(BaseFormDto.SectionNumber))!.GetValue(monitoringDto)!.ToString();
            var section = await _genericRepository.GetFirstByParameterAsync<FormSection>(e => e.SectionNumber == sectionNumber);
            if (section == null)
                return await Result<object>.FailAsync($"Section with id={sectionNumber} not found!");

            var items = await _genericRepository.GetAllByParameterAsync<FormItem>(e => e.FormSectionId == section.SectionId, 
                                                                            query => query.Include(e => e.FormItemType));

            List<ReportResponse> result = GetPropertiesAndValues(monitoringDto, items.ToArray());

            return await Result<object>.SuccessAsync(result);
        }

        private async Task<Result<OrgMonitoring>> GetFilledEntity<T>(T report, DocInfo docInfo, IFormCollection? fileItems = null)
        where T : OrgMonitoring
        {
            var Organization = await _genericRepository.GetByIdAsync<Organization>(report.OrganizationId) 
                               ?? throw new NullReferenceException($"with id={report.OrganizationId} organization not found!");
            
            OrgMonitoringDto Dto = new(Organization.FullName, report.Year, report.QuarterIndex, report.SectionNumber);

            var fileModels = await ProcessMultipleFiles(fileItems, Dto, docInfo);

            PropertyInfo fileModelProperty;

            switch (report)
            {

                case Form1_1_1:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    fileModelProperty = report.GetType().GetProperty(nameof(Form1_1_1.FileModel))!;
                    
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form1_1_2:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    fileModelProperty = report.GetType().GetProperty(nameof(Form1_1_2.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form1_1_3:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    fileModelProperty = report.GetType().GetProperty(nameof(Form1_1_3.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_1_1:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_1_1.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_1_2:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_1_2.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_2_1:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_2_1.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_2_2:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    PropertyInfo relatedFiles =
                    report.GetType().GetProperty(nameof(Form2_2_2.FileModels))!;
                    
                    relatedFiles.SetValue(report, fileModels);
                    break;

                case Form2_3_1:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_3_1.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_3_2:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

                    fileModelProperty = report.GetType().GetProperty(nameof(Form2_3_2.FileModel))!;
                    fileModelProperty.SetValue(report, fileModels.First());
                    break;

                case Form2_8_1:

                    if (fileModels.Count == 0)
                        throw new NotSupportedException($"No files received!");

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

        private async Task<List<FileModel>> ProcessMultipleFiles(IFormCollection? fileItems, OrgMonitoringDto dto, DocInfo docInfo)
        {
            if (fileItems is null)
            {
                throw new NotSupportedException($"No files received.");
            }

            List<FileModel> fileModels = new();

            foreach (var file in fileItems.Files)
            {
                var fileItem = new FileItem(file,"файл", docInfo.DocNumber, docInfo.DocDate);
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
            oldEntity = newEntity switch
            {
                Form1_1_1 => await _genericRepository.GetFirstByParameterAsync<Form1_1_1>(e => e.MonitoringId == oldEntityId,
                                                                                               query => query.Include(e => e.FileModel)),
                Form1_1_2 => await _genericRepository.GetFirstByParameterAsync<Form1_1_2>(e => e.MonitoringId == oldEntityId,
                                                                                               query => query.Include(e => e.FileModel)),
                Form1_1_3 => await _genericRepository.GetFirstByParameterAsync<Form1_1_3>(e => e.MonitoringId == oldEntityId,
                                                                                               query => query.Include(e => e.FileModel)),
                Form2_1_1 => await _genericRepository.GetFirstByParameterAsync<Form2_1_1>(e => e.MonitoringId == oldEntityId,
                                                                                               query => query.Include(e => e.FileModel)),
                Form2_1_2 => await _genericRepository.GetFirstByParameterAsync<Form2_1_2>(e => e.MonitoringId == oldEntityId,
                                                                                               query => query.Include(e => e.FileModel)),
                Form2_2_1 => await _genericRepository.GetFirstByParameterAsync<Form2_2_1>(e => e.MonitoringId == oldEntityId,
                                                                                               query => query.Include(e => e.FileModel)),
                Form2_2_2 => await _genericRepository.GetFirstByParameterAsync<Form2_2_2>(e => e.MonitoringId == oldEntityId,
                                                                                                query => query.Include(e => e.TimelyExecutionOfPlans)),
                Form2_3_1 => await _genericRepository.GetFirstByParameterAsync<Form2_3_1>(e => e.MonitoringId == oldEntityId,
                                                                                               query => query.Include(e => e.FileModel)),
                Form2_3_2 => await _genericRepository.GetFirstByParameterAsync<Form2_3_2>(e => e.MonitoringId == oldEntityId,
                                                                                               query => query.Include(e => e.FileModel)),
                Form2_8_1 => await _genericRepository.GetFirstByParameterAsync<Form2_8_1>(e => e.MonitoringId == oldEntityId,
                                                                                                query => query.Include(e => e.QualificationImprovedEmployees)
                                                                                                .ThenInclude(q => q.Certificate)),
                _ => entity,
            };

            if (oldEntity == null)
            {
                await _genericRepository.AddAsync(newEntity);
                return;
            }

            _mapper.Map(newEntity, oldEntity);

            await _genericRepository.UpdateAsync(oldEntity);
        }

        private static List<ReportResponse> GetPropertiesAndValues(object obj, FormItem[] items, int order = 1)
        {
            List<ReportResponse> list = new ();

            bool ToBeDisplayed;
            string PropertyLabel;
            string ItemType;
            int Order = order;
            string PropertyName;

            var Properties = obj.GetType().GetProperties();

            if(obj is Form2_8_1Dto)
            {
                Properties = obj.GetType().GetProperty(nameof(Form2_8_1Dto.QualificationImprovedEmployees))!.GetType().GetGenericArguments()[0].GetProperties();
            }

            FormItem[] SelectedItems = new FormItem[Properties.Length];
            
            for(int j=0; j<Properties.Length; j++)
            {  
                PropertyName = Properties[j].Name.Equals("FileId") ? "FileItem" : Properties[j].Name;
                
                for (int i = 0; i< items.Length; i++)
                {
                    if (PropertyName.Equals(items[i].ItemName))
                    {
                        SelectedItems[j] = items[i];
                        break;
                    }
                }
            }

            ///</> item.Count() is considered less than or equal to Properties.Count() </>

            for (int i = 0; i < Properties.Length; i++)
            {
                var orderAttr = Properties[i].GetCustomAttribute<PropertyOrderAttribute>();

                if (Properties[i].DeclaringType != typeof(BaseFormDto))
                {
                    ToBeDisplayed = true;
                    PropertyLabel = SelectedItems[i].ItemLabel;
                    ItemType = SelectedItems[i].FormItemType.TypeName;
                }

                else
                {
                    PropertyLabel = Properties[i].Name;
                    ToBeDisplayed = false;
                    ItemType = string.Empty;
                }

                if (orderAttr != null)
                {
                    if (order == 1)
                        Order = orderAttr.Order;

                    list.Add(new ReportResponse(PropertyLabel, Properties[i].GetValue(obj, null)!, Order, ItemType, ToBeDisplayed));
                }

                else
                {
                    list.Add(new ReportResponse(PropertyLabel, Properties[i].GetValue(obj, null)!, int.MaxValue, ItemType, ToBeDisplayed));
                }

                if(order != 1)
                    Order++;
            }

            return list;
        }

        public async Task<Result<object>> GetQuarterReportByQb(ReportRequestByQb reportRequest)
        {
            var sections = await _genericRepository.GetAllByParameterAsync<FormSection>(e => e.QuestionBlockId == reportRequest.QbId);
            if (!sections.Any())
                return await Result<object>.FailAsync($"No sections connected to question block with id ={reportRequest.QbId} found!");

            IEnumerable<Organization> organizations = new List<Organization>();

            if(reportRequest.OrganizationId == 0)
            {
                organizations = await _genericRepository.GetAllAsync<Organization>();
            }

            else
            {
                var organization = await _genericRepository.GetByIdAsync<Organization>(reportRequest.OrganizationId);
                if(organization != null)
                {
                    List<Organization> temp = new()
                    {
                        organization
                    };

                    organizations = temp;
                }

            }

            Dictionary<string, FormItem[]> dictOfItemArrays = new();

            List<List<ReportResponse>> finalResponseList = new();

            foreach(var org in organizations)
            {
                List<ReportResponse> responseList = new()
                {
                    new ReportResponse("Наименование структурных подразделений", org.FullName, 0, string.Empty, true)
                };

                object? blockDto = null;
                
                List<FormItem> formItems = new();

                foreach (var section in sections)
                {

                    var report = await GetReportDto(new ReportRequest(section.SectionNumber, org.OrganizationId, reportRequest.Year, reportRequest.Quarter), blockDto);

                    blockDto = report;
                    
                    var items = await _genericRepository.GetAllByParameterAsync<FormItem>(e => e.FormSectionId == section.SectionId, 
                                                                                                query => query.Include(e => e.FormItemType));

                    formItems.AddRange(items);
                }

                var responseObjList = GetPropertiesAndValues(blockDto!, formItems.ToArray());

                responseList.AddRange(responseObjList); 

                finalResponseList.Add(responseList);
            }

            return await Result<object>.SuccessAsync(finalResponseList);

        }

        private async Task<object> GetReportDto(ReportRequest reportRequest, object? blockDto)
        {

            object report;

            switch (reportRequest.SectionNumber)
            {
                case FormType.Form1_1_1:
                    Expression<Func<Form1_1_1, bool>> predicate1_1_1 = BuildPredicate<Form1_1_1>(reportRequest);
                    report = await FetchAndMapData<Form1_1_1, Block1_1Dto>(predicate1_1_1, blockDto);
                    break;

                case FormType.Form1_1_2:
                    Expression<Func<Form1_1_2, bool>> predicate1_1_2 = BuildPredicate<Form1_1_2>(reportRequest);
                    report = await FetchAndMapData<Form1_1_2, Block1_1Dto>(predicate1_1_2, blockDto);

                    break;

                case FormType.Form1_1_3:
                    Expression<Func<Form1_1_3, bool>> predicate1_1_3 = BuildPredicate<Form1_1_3>(reportRequest);
                    report = await FetchAndMapData<Form1_1_3, Block1_1Dto>(predicate1_1_3, blockDto);

                    break;

                case FormType.Form1_1_4:
                    Expression<Func<Form1_1_4, bool>> predicate1_1_4 = BuildPredicate<Form1_1_4>(reportRequest);
                    report = await FetchAndMapData<Form1_1_4, Block1_1Dto>(predicate1_1_4, blockDto);
                    break;

                case FormType.Form1_1_5:
                    Expression<Func<Form1_1_5, bool>> predicate1_1_5 = BuildPredicate<Form1_1_5>(reportRequest);
                    report = await FetchAndMapData<Form1_1_5, Block1_1Dto>(predicate1_1_5, blockDto);
                    break;

                case FormType.Form1_1_6:
                    Expression<Func<Form1_1_6, bool>> predicate1_1_6 = BuildPredicate<Form1_1_6>(reportRequest);
                    report = await FetchAndMapData<Form1_1_6, Block1_1Dto>(predicate1_1_6, blockDto);
                    break;
                case FormType.Form1_2_1:
                    Expression<Func<Form1_2_1, bool>> predicate1_2_1 = BuildPredicate<Form1_2_1>(reportRequest);
                    report = await FetchAndMapData<Form1_2_1, Block1_2Dto>(predicate1_2_1, blockDto);
                    break;
                case FormType.Form1_3_1:
                    Expression<Func<Form1_3_1, bool>> predicate1_3_1 = BuildPredicate<Form1_3_1>(reportRequest);
                    report = await FetchAndMapData<Form1_3_1, Block1_3Dto>(predicate1_3_1, blockDto);
                    break;
                case FormType.Form1_4_1:
                    Expression<Func<Form1_4_1, bool>> predicate1_4_1 = BuildPredicate<Form1_4_1>(reportRequest);
                    report = await FetchAndMapData<Form1_4_1, Block1_4Dto>(predicate1_4_1, blockDto);
                    break;
                case FormType.Form1_4_2:
                    Expression<Func<Form1_4_2, bool>> predicate1_4_2 = BuildPredicate<Form1_4_2>(reportRequest);
                    report = await FetchAndMapData<Form1_4_2, Block1_4Dto>(predicate1_4_2, blockDto);
                    break;
                case FormType.Form1_4_3:
                    Expression<Func<Form1_4_3, bool>> predicate1_4_3 = BuildPredicate<Form1_4_3>(reportRequest);
                    report = await FetchAndMapData<Form1_4_3, Block1_4Dto>(predicate1_4_3, blockDto);
                    break;
                case FormType.Form1_4_4:
                    Expression<Func<Form1_4_4, bool>> predicate1_4_4 = BuildPredicate<Form1_4_4>(reportRequest);
                    report = await FetchAndMapData<Form1_4_4, Block1_4Dto>(predicate1_4_4, blockDto);
                    break;
                case FormType.Form1_5_1:
                    Expression<Func<Form1_5_1, bool>> predicate1_5_1 = BuildPredicate<Form1_5_1>(reportRequest);
                    report = await FetchAndMapData<Form1_5_1, Block1_5Dto>(predicate1_5_1, blockDto);
                    break;
                case FormType.Form1_5_2:
                    Expression<Func<Form1_5_2, bool>> predicate1_5_2 = BuildPredicate<Form1_5_2>(reportRequest);
                    report = await FetchAndMapData<Form1_5_2, Block1_5Dto>(predicate1_5_2, blockDto);
                    break;
                case FormType.Form1_5_3:
                    Expression<Func<Form1_5_3, bool>> predicate1_5_3 = BuildPredicate<Form1_5_3>(reportRequest);
                    report = await FetchAndMapData<Form1_5_3, Block1_5Dto>(predicate1_5_3, blockDto);
                    break;
                case FormType.Form2_1_1:
                    Expression<Func<Form2_1_1, bool>> predicate2_1_1 = BuildPredicate<Form2_1_1>(reportRequest);
                    report = await FetchAndMapData<Form2_1_1, Block2_1Dto>(predicate2_1_1, blockDto);
                    break;
                case FormType.Form2_1_2:
                    Expression<Func<Form2_1_2, bool>> predicate2_1_2 = BuildPredicate<Form2_1_2>(reportRequest);
                    report = await FetchAndMapData<Form2_1_2, Block2_1Dto>(predicate2_1_2, blockDto);
                    break;
                case FormType.Form2_2_1:
                    Expression<Func<Form2_2_1, bool>> predicate2_2_1 = BuildPredicate<Form2_2_1>(reportRequest);
                    report = await FetchAndMapData<Form2_2_1, Block2_2Dto>(predicate2_2_1, blockDto);
                    break;
                case FormType.Form2_2_2:
                    Expression<Func<Form2_2_2, bool>> predicate2_2_2 = BuildPredicate<Form2_2_2>(reportRequest);
                    report = await FetchAndMapData<Form2_2_2, Block2_2Dto>(predicate2_2_2, blockDto);
                    break;
                case FormType.Form2_3_1:
                    Expression<Func<Form2_3_1, bool>> predicate2_3_1 = BuildPredicate<Form2_3_1>(reportRequest);
                    report = await FetchAndMapData<Form2_3_1, Block2_3Dto>(predicate2_3_1, blockDto);
                    break;
                case FormType.Form2_3_2:
                    Expression<Func<Form2_3_2, bool>> predicate2_3_2 = BuildPredicate<Form2_3_2>(reportRequest);
                    report = await FetchAndMapData<Form2_3_2, Block2_3Dto>(predicate2_3_2, blockDto);
                    break;
                case FormType.Form2_3_3:
                    Expression<Func<Form2_3_3, bool>> predicate2_3_3 = BuildPredicate<Form2_3_3>(reportRequest);
                    report = await FetchAndMapData<Form2_3_3, Block2_3Dto>(predicate2_3_3, blockDto);
                    break;
                case FormType.Form2_3_4:
                    Expression<Func<Form2_3_4, bool>> predicate2_3_4 = BuildPredicate<Form2_3_4>(reportRequest);
                    report = await FetchAndMapData<Form2_3_4, Block2_3Dto>(predicate2_3_4, blockDto);
                    break;
                case FormType.Form2_4_1:
                    Expression<Func<Form2_4_1, bool>> predicate2_4_1 = BuildPredicate<Form2_4_1>(reportRequest);
                    report = await FetchAndMapData<Form2_4_1, Block2_4Dto>(predicate2_4_1, blockDto);
                    break;
                case FormType.Form2_4_2:
                    Expression<Func<Form2_4_2, bool>> predicate2_4_2 = BuildPredicate<Form2_4_2>(reportRequest);
                    report = await FetchAndMapData<Form2_4_2, Block2_4Dto>(predicate2_4_2, blockDto);
                    break;
                case FormType.Form2_4_3:
                    Expression<Func<Form2_4_3, bool>> predicate2_4_3 = BuildPredicate<Form2_4_3>(reportRequest);
                    report = await FetchAndMapData<Form2_4_3, Block2_4Dto>(predicate2_4_3, blockDto);
                    break;
                case FormType.Form2_5_1:
                    Expression<Func<Form2_5_1, bool>> predicate2_5_1 = BuildPredicate<Form2_5_1>(reportRequest);
                    report = await FetchAndMapData<Form2_5_1, Block2_5Dto>(predicate2_5_1, blockDto);
                    break;
                case FormType.Form2_6_1:
                    Expression<Func<Form2_6_1, bool>> predicate2_6_1 = BuildPredicate<Form2_6_1>(reportRequest);
                    report = await FetchAndMapData<Form2_6_1, Block2_6Dto>(predicate2_6_1, blockDto);
                    break;
                case FormType.Form2_7_1:
                    Expression<Func<Form2_7_1, bool>> predicate2_7_1 = BuildPredicate<Form2_7_1>(reportRequest);
                    report = await FetchAndMapData<Form2_7_1, Block2_7Dto>(predicate2_7_1, blockDto);
                    break;
                case FormType.Form2_8_1:
                    Expression<Func<Form2_8_1, bool>> predicate2_8_1 = BuildPredicate<Form2_8_1>(reportRequest);
                    report = await FetchAndMapData<Form2_8_1, Block2_8Dto>(predicate2_8_1, blockDto);
                    break;
                case FormType.Form2_9_1:
                    Expression<Func<Form2_9_1, bool>> predicate2_9_1 = BuildPredicate<Form2_9_1>(reportRequest);
                    report = await FetchAndMapData<Form2_9_1, Block2_9Dto>(predicate2_9_1, blockDto);
                    break;
                case FormType.Form2_10_1:
                    Expression<Func<Form2_10_1, bool>> predicate2_10_1 = BuildPredicate<Form2_10_1>(reportRequest);
                    report = await FetchAndMapData<Form2_10_1, Block2_10Dto>(predicate2_10_1, blockDto);
                    break;
                case FormType.Form2_11_1:
                    Expression<Func<Form2_11_1, bool>> predicate2_11_1 = BuildPredicate<Form2_11_1>(reportRequest);
                    report = await FetchAndMapData<Form2_11_1, Block2_11Dto>(predicate2_11_1, blockDto);
                    break;
                case FormType.Form2_11_2:
                    Expression<Func<Form2_11_2, bool>> predicate2_11_2 = BuildPredicate<Form2_11_2>(reportRequest);
                    report = await FetchAndMapData<Form2_11_2, Block2_11Dto>(predicate2_11_2, blockDto);
                    break;
                case FormType.Form2_11_3:
                    Expression<Func<Form2_11_3, bool>> predicate2_11_3 = BuildPredicate<Form2_11_3>(reportRequest);
                    report = await FetchAndMapData<Form2_11_3, Block2_11Dto>(predicate2_11_3, blockDto);
                    break;
                case FormType.Form2_11_4:
                    Expression<Func<Form2_11_4, bool>> predicate2_11_4 = BuildPredicate<Form2_11_4>(reportRequest);
                    report = await FetchAndMapData<Form2_11_4, Block2_11Dto>(predicate2_11_4, blockDto);
                    break;
                case FormType.Form2_11_5:
                    Expression<Func<Form2_11_5, bool>> predicate2_11_5 = BuildPredicate<Form2_11_5>(reportRequest);
                    report = await FetchAndMapData<Form2_11_5, Block2_11Dto>(predicate2_11_5, blockDto);
                    break;
                case FormType.Form2_11_6:
                    Expression<Func<Form2_11_6, bool>> predicate2_11_6 = BuildPredicate<Form2_11_6>(reportRequest);
                    report = await FetchAndMapData<Form2_11_6, Block2_11Dto>(predicate2_11_6, blockDto);
                    break;
                case FormType.Form2_11_7:
                    Expression<Func<Form2_11_7, bool>> predicate2_11_7 = BuildPredicate<Form2_11_7>(reportRequest);
                    report = await FetchAndMapData<Form2_11_7, Block2_11Dto>(predicate2_11_7, blockDto);
                    break;
                case FormType.Form2_12_1:
                    Expression<Func<Form2_12_1, bool>> predicate2_12_1 = BuildPredicate<Form2_12_1>(reportRequest);
                    report = await FetchAndMapData<Form2_12_1, Block2_12Dto>(predicate2_12_1, blockDto);
                    break;
                case FormType.Form2_13_1:
                    Expression<Func<Form2_13_1, bool>> predicate2_13_1 = BuildPredicate<Form2_13_1>(reportRequest);
                    report = await FetchAndMapData<Form2_13_1, Block2_13Dto>(predicate2_13_1, blockDto);
                    break;
                case FormType.Form2_14_1:
                    Expression<Func<Form2_14_1, bool>> predicate2_14_1 = BuildPredicate<Form2_14_1>(reportRequest);
                    report = await FetchAndMapData<Form2_14_1, Block2_14Dto>(predicate2_14_1, blockDto);
                    break;
                case FormType.Form2_15_1:
                    Expression<Func<Form2_15_1, bool>> predicate2_15_1 = BuildPredicate<Form2_15_1>(reportRequest);
                    report = await FetchAndMapData<Form2_15_1, Block2_15Dto>(predicate2_15_1, blockDto);
                    break;
                case FormType.Form2_16_1:
                    Expression<Func<Form2_16_1, bool>> predicate2_16_1 = BuildPredicate<Form2_16_1>(reportRequest);
                    report = await FetchAndMapData<Form2_16_1, Block2_16Dto>(predicate2_16_1, blockDto);
                    break;
                case FormType.Form2_17_1:
                    Expression<Func<Form2_17_1, bool>> predicate2_17_1 = BuildPredicate<Form2_17_1>(reportRequest);
                    report = await FetchAndMapData<Form2_17_1, Block2_17Dto>(predicate2_17_1, blockDto);
                    break;
                case FormType.Form2_18_1:
                    Expression<Func<Form2_18_1, bool>> predicate2_18_1 = BuildPredicate<Form2_18_1>(reportRequest);
                    report = await FetchAndMapData<Form2_18_1, Block2_18Dto>(predicate2_18_1, blockDto);
                    break;
                case FormType.Form3_1_1:
                    Expression<Func<Form3_1_1, bool>> predicate3_1_1 = BuildPredicate<Form3_1_1>(reportRequest);
                    report = await FetchAndMapData<Form3_1_1, Block3_1Dto>(predicate3_1_1, blockDto);
                    break;
                case FormType.Form3_1_2:
                    Expression<Func<Form3_1_2, bool>> predicate3_1_2 = BuildPredicate<Form3_1_2>(reportRequest);
                    report = await FetchAndMapData<Form3_1_2, Block3_1Dto>(predicate3_1_2, blockDto);
                    break;
                case FormType.Form3_2_1:
                    Expression<Func<Form3_2_1, bool>> predicate3_2_1 = BuildPredicate<Form3_2_1>(reportRequest);
                    report = await FetchAndMapData<Form3_2_1, Block3_2Dto>(predicate3_2_1, blockDto);
                    break;
                case FormType.Form3_2_2:
                    Expression<Func<Form3_2_2, bool>> predicate3_2_2 = BuildPredicate<Form3_2_2>(reportRequest);
                    report = await FetchAndMapData<Form3_2_2, Block3_2Dto>(predicate3_2_2, blockDto);
                    break;
                case FormType.Form3_3_1:
                    Expression<Func<Form3_3_1, bool>> predicate3_3_1 = BuildPredicate<Form3_3_1>(reportRequest);
                    report = await FetchAndMapData<Form3_3_1, Block3_3Dto>(predicate3_3_1, blockDto);
                    break;
                case FormType.Form3_4_1:
                    Expression<Func<Form3_4_1, bool>> predicate3_4_1 = BuildPredicate<Form3_4_1>(reportRequest);
                    report = await FetchAndMapData<Form3_4_1, Block3_4Dto>(predicate3_4_1, blockDto);
                    break;
                case FormType.Form3_5_1:
                    Expression<Func<Form3_5_1, bool>> predicate3_5_1 = BuildPredicate<Form3_5_1>(reportRequest);
                    report = await FetchAndMapData<Form3_5_1, Block3_5Dto>(predicate3_5_1, blockDto);
                    break;
                case FormType.Form3_6_1:
                    Expression<Func<Form3_6_1, bool>> predicate3_6_1 = BuildPredicate<Form3_6_1>(reportRequest);
                    report = await FetchAndMapData<Form3_6_1, Block3_6Dto>(predicate3_6_1, blockDto);
                    break;
                case FormType.Form3_7_1:
                    Expression<Func<Form3_7_1, bool>> predicate3_7_1 = BuildPredicate<Form3_7_1>(reportRequest);
                    report = await FetchAndMapData<Form3_7_1, Block3_7Dto>(predicate3_7_1, blockDto);
                    break;
                case FormType.Form3_8_1:
                    Expression<Func<Form3_8_1, bool>> predicate3_8_1 = BuildPredicate<Form3_8_1>(reportRequest);
                    report = await FetchAndMapData<Form3_8_1, Block3_8Dto>(predicate3_8_1, blockDto);
                    break;
                case FormType.Form3_9_1:
                    Expression<Func<Form3_9_1, bool>> predicate3_9_1 = BuildPredicate<Form3_9_1>(reportRequest);
                    report = await FetchAndMapData<Form3_9_1, Block3_9Dto>(predicate3_9_1, blockDto);
                    break;
                case FormType.Form3_10_1:
                    Expression<Func<Form3_10_1, bool>> predicate3_10_1 = BuildPredicate<Form3_10_1>(reportRequest);
                    report = await FetchAndMapData<Form3_10_1, Block3_10Dto>(predicate3_10_1, blockDto);
                    break;
                case FormType.Form3_11_1:
                    Expression<Func<Form3_11_1, bool>> predicate3_11_1 = BuildPredicate<Form3_11_1>(reportRequest);
                    report = await FetchAndMapData<Form3_11_1, Block3_11Dto>(predicate3_11_1, blockDto);
                    break;
                case FormType.Form3_12_1:
                    Expression<Func<Form3_12_1, bool>> predicate3_12_1 = BuildPredicate<Form3_12_1>(reportRequest);
                    report = await FetchAndMapData<Form3_12_1, Block3_12Dto>(predicate3_12_1, blockDto);
                    break;
                case FormType.Form3_13_1:
                    Expression<Func<Form3_13_1, bool>> predicate3_13_1 = BuildPredicate<Form3_13_1>(reportRequest);
                    report = await FetchAndMapData<Form3_13_1, Block3_13Dto>(predicate3_13_1, blockDto);
                    break;
                default:
                    throw new NotSupportedException($"Section number with <{reportRequest.SectionNumber}> not found!");
            }

            return report;

        }

        private static Expression<Func<T, bool>> BuildPredicate<T>(ReportRequest reportRequest) where T : OrgMonitoring
        {
            return entity => entity.Year == reportRequest.Year &&
                             entity.QuarterIndex == reportRequest.Quarter &&
                             entity.OrganizationId == reportRequest.OrganizationId;
        }

        private async Task<TDto> FetchAndMapData<TEntity, TDto>(Expression<Func<TEntity, bool>> predicate, object? blockDto)

            where TEntity : OrgMonitoring, new()
            where TDto : class, new()
        {

            var entity = await _genericRepository.GetFirstByParameterAsync(predicate);
            if (blockDto == null)
                return entity == null ? new TDto() : _mapper.Map<TDto>(entity);
            else
                return (TDto)(entity == null ? blockDto : _mapper.Map(entity, blockDto));
        }
    }
}
