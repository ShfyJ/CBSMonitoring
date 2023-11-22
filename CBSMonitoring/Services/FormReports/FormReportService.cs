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
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Net;

namespace CBSMonitoring.Services.FormReports
{
    public class FormReportService : IMonitoringFactory
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IFileWorkRoom _fileWorkRoom;
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _applicationUserService;
        private readonly Dictionary<string, Func<ReportRequest, object?, Task<object>>> _formTypeHandlers;
        public FormReportService(IGenericRepository genericRepository,
            IFileWorkRoom fileWorkRoom, IMapper mapper,
            IApplicationUserService applicationUserService)
        {
            _genericRepository = genericRepository;
            _fileWorkRoom = fileWorkRoom;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            _formTypeHandlers = new Dictionary<string, Func<ReportRequest, object?, Task<object>>>
                {
                    { FormType.Form1_1_1, FetchAndMap < Form1_1_1, Block1_1Dto > },
                    { FormType.Form1_1_2, FetchAndMap < Form1_1_2, Block1_1Dto > },
                    { FormType.Form1_1_3, FetchAndMap < Form1_1_3, Block1_1Dto > },
                    { FormType.Form1_1_4, FetchAndMap < Form1_1_4, Block1_1Dto > },
                    { FormType.Form1_1_5, FetchAndMap < Form1_1_5, Block1_1Dto > },
                    { FormType.Form1_1_6, FetchAndMap < Form1_1_6, Block1_1Dto > },
                    { FormType.Form1_2_1, FetchAndMap < Form1_2_1, Block1_2Dto > },
                    { FormType.Form1_3_1, FetchAndMap < Form1_3_1, Block1_3Dto > },
                    { FormType.Form1_4_1, FetchAndMap < Form1_4_1, Block1_4Dto > },
                    { FormType.Form1_4_2, FetchAndMap < Form1_4_2, Block1_4Dto > },
                    { FormType.Form1_4_3, FetchAndMap < Form1_4_3, Block1_4Dto > },
                    { FormType.Form1_4_4, FetchAndMap < Form1_4_4, Block1_4Dto > },
                    { FormType.Form1_5_1, FetchAndMap < Form1_5_1, Block1_5Dto > },
                    { FormType.Form1_5_2, FetchAndMap < Form1_5_2, Block1_5Dto > },
                    { FormType.Form1_5_3, FetchAndMap < Form1_5_3, Block1_5Dto > },
                    { FormType.Form2_1_1, FetchAndMap < Form2_1_1, Block2_1Dto > },
                    { FormType.Form2_1_2, FetchAndMap < Form2_1_2, Block2_1Dto > },
                    { FormType.Form2_2_1, FetchAndMap < Form2_2_1, Block2_2Dto > },
                    { FormType.Form2_2_2, FetchAndMap < Form2_2_2, Block2_2Dto > },
                    { FormType.Form2_3_1, FetchAndMap < Form2_3_1, Block2_3Dto > },
                    { FormType.Form2_3_2, FetchAndMap < Form2_3_2, Block2_3Dto > },
                    { FormType.Form2_3_3, FetchAndMap < Form2_3_3, Block2_3Dto > },
                    { FormType.Form2_3_4, FetchAndMap < Form2_3_4, Block2_3Dto > },
                    { FormType.Form2_4_1, FetchAndMap < Form2_4_1, Block2_4Dto > },
                    { FormType.Form2_4_2, FetchAndMap < Form2_4_2, Block2_4Dto > },
                    { FormType.Form2_4_3, FetchAndMap < Form2_4_3, Block2_4Dto > },
                    { FormType.Form2_5_1, FetchAndMap < Form2_5_1, Block2_5Dto > },
                    { FormType.Form2_6_1, FetchAndMap < Form2_6_1, Block2_6Dto > },
                    { FormType.Form2_7_1, FetchAndMap < Form2_7_1, Block2_7Dto > },
                    { FormType.Form2_8_1, FetchAndMap < Form2_8_1, Block2_8Dto > },
                    { FormType.Form2_9_1, FetchAndMap < Form2_9_1, Block2_9Dto > },
                    { FormType.Form2_10_1, FetchAndMap < Form2_10_1, Block2_10Dto > },
                    { FormType.Form2_11_1, FetchAndMap < Form2_11_1, Block2_11Dto > },
                    { FormType.Form2_11_2, FetchAndMap < Form2_11_2, Block2_11Dto > },
                    { FormType.Form2_11_3, FetchAndMap < Form2_11_3, Block2_11Dto > },
                    { FormType.Form2_11_4, FetchAndMap < Form2_11_4, Block2_11Dto > },
                    { FormType.Form2_11_5, FetchAndMap < Form2_11_5, Block2_11Dto > },
                    { FormType.Form2_11_6, FetchAndMap < Form2_11_6, Block2_11Dto > },
                    { FormType.Form2_11_7, FetchAndMap < Form2_11_7, Block2_11Dto > },
                    { FormType.Form2_12_1, FetchAndMap < Form2_12_1, Block2_12Dto > },
                    { FormType.Form2_13_1, FetchAndMap < Form2_13_1, Block2_13Dto > },
                    { FormType.Form2_14_1, FetchAndMap < Form2_14_1, Block2_14Dto > },
                    { FormType.Form2_15_1, FetchAndMap < Form2_15_1, Block2_15Dto > },
                    { FormType.Form2_16_1, FetchAndMap < Form2_16_1, Block2_16Dto > },
                    { FormType.Form2_17_1, FetchAndMap < Form2_17_1, Block2_17Dto > },
                    { FormType.Form2_18_1, FetchAndMap < Form2_18_1, Block2_18Dto > },                    
                    { FormType.Form3_1_1, FetchAndMap < Form3_1_1, Block3_1Dto > },
                    { FormType.Form3_1_2, FetchAndMap < Form3_1_2, Block3_1Dto > },
                    { FormType.Form3_2_1, FetchAndMap < Form3_2_1, Block3_2Dto > },
                    { FormType.Form3_2_2, FetchAndMap < Form3_2_2, Block3_2Dto > },
                    { FormType.Form3_3_1, FetchAndMap < Form3_3_1, Block3_3Dto > },
                    { FormType.Form3_4_1, FetchAndMap < Form3_4_1, Block3_4Dto > },
                    { FormType.Form3_5_1, FetchAndMap < Form3_5_1, Block3_5Dto > },
                    { FormType.Form3_6_1, FetchAndMap < Form3_6_1, Block3_6Dto > },
                    { FormType.Form3_7_1, FetchAndMap < Form3_7_1, Block3_7Dto > },
                    { FormType.Form3_8_1, FetchAndMap < Form3_8_1, Block3_8Dto > },
                    { FormType.Form3_9_1, FetchAndMap < Form3_9_1, Block3_9Dto > },
                    { FormType.Form3_10_1, FetchAndMap < Form3_10_1, Block3_10Dto > },
                    { FormType.Form3_11_1, FetchAndMap < Form3_11_1, Block3_11Dto > },
                    { FormType.Form3_12_1, FetchAndMap < Form3_12_1, Block3_12Dto > },
                    { FormType.Form3_13_1, FetchAndMap < Form3_13_1, Block3_13Dto > },
                };
        }

        public async Task<Result<string>> AddMonitoringReport<T>(MonitoringDto reportForm, string sectionNumber, IFormCollection? fileItems = null)
            where T : OrgMonitoring
        {
            
            try
            {
                T report = _mapper.Map<T>(reportForm);

                report.CreatedDateTime = DateTime.Now;
                report.SectionNumber = sectionNumber;

                var orgIdResult = await GetOrganizationId(report.OrganizationId);

                if (!orgIdResult.Succeeded)
                {
                    return await Result<string>.FailAsync(
                        orgIdResult.Code, orgIdResult.Messages);
                }

                report.OrganizationId = orgIdResult.Data;

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
            // Get current user's organization Id

            var orgIdResult = await GetOrganizationId(reportRequest.OrganizationId);

            if (!orgIdResult.Succeeded)
            {
                return await Result<object>.FailAsync(
                    orgIdResult.Code, orgIdResult.Messages);
            }

            reportRequest.OrganizationId = orgIdResult.Data;

            // Get the report according to given criteria

            OrgMonitoring? report = reportRequest.SectionNumber switch
            {
                FormType.Form1_1_1 => await _genericRepository.GetFirstByParameterAsync<Form1_1_1>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form1_1_2 => await _genericRepository.GetFirstByParameterAsync<Form1_1_2>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form1_1_3 => await _genericRepository.GetFirstByParameterAsync<Form1_1_3>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_1_1 => await _genericRepository.GetFirstByParameterAsync<Form2_1_1>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_1_2 => await _genericRepository.GetFirstByParameterAsync<Form2_1_2>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_2_1 => await _genericRepository.GetFirstByParameterAsync<Form2_2_1>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_2_2 => await _genericRepository.GetFirstByParameterAsync<Form2_2_2>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.TimelyExecutionOfPlans).Include(e => e.FileModels)),
                FormType.Form2_3_1 => await _genericRepository.GetFirstByParameterAsync<Form2_3_1>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_3_2 => await _genericRepository.GetFirstByParameterAsync<Form2_3_2>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.FileModel)),
                FormType.Form2_8_1 => await _genericRepository.GetFirstByParameterAsync<Form2_8_1>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization).Include(e => e.QualificationImprovedEmployees)),
                _ => await _genericRepository.GetFirstByParameterAsync<T>(e => e.Year == reportRequest.Period.Year && e.QuarterIndex == reportRequest.Period.Quarter
                                                                                            && e.OrganizationId == reportRequest.OrganizationId,
                                                                                            query => query.Include(e => e.Organization)),
            };

            if (report == null)
                return await Result<object>.FailAsync($"Current quarter report with section number = {reportRequest.SectionNumber} " +
                                                        $"and organization Id = {reportRequest.OrganizationId} not found!");
            // Map report object into dto object
            var monitoringDto = _mapper.Map<TDto>(report);

            var sectionNumber = monitoringDto.GetType().GetProperty(nameof(BaseFormDto.SectionNumber))!.GetValue(monitoringDto)!.ToString();
            var section = await _genericRepository.GetFirstByParameterAsync<FormSection>(e => e.SectionNumber == sectionNumber);
            if (section == null)
                return await Result<object>.FailAsync($"Section with id={sectionNumber} not found!");

            // Fetch form items connected to this section
            var items = await _genericRepository.GetAllAsync<FormItem>(e => e.FormSectionId == section.SectionId, 
                                                                            query => query.Include(e => e.FormItemType));

            // Generate a list where properties' information (name, value, type,etc.) of the report object stored
            List<ReportResponse> result = GetPropertiesAndValues(monitoringDto, items.ToArray());

            return await Result<object>.SuccessAsync(result);
        }
        public async Task<Result<object>> GetQuarterReportByQb(ReportRequestByQb reportRequest)
        {
            var sections = await GetSectionsByQbId(reportRequest.QbId);
            if (!sections.Any())
                return await Result<object>.FailAsync($"No sections connected to question block with id ={reportRequest.QbId} found!");

            // Get current user's organization id or check if user is authorized for this organization info
            var orgIdResult = await GetOrganizationId(reportRequest.OrganizationId);

            if (!orgIdResult.Succeeded)
            {
                return await Result<object>.FailAsync(
                    orgIdResult.Code, orgIdResult.Messages);
            }

            reportRequest.OrganizationId = orgIdResult.Data;

            var organizations = await GetOrganizations(reportRequest.OrganizationId);

            var finalResponses = await BuildFinalResponses(organizations, sections, reportRequest);

            return await Result<object>.SuccessAsync(finalResponses);

        }

        #region private methods
        private async Task<Result<OrgMonitoring>> GetFilledEntity<T>(T report, DocInfo docInfo, IFormCollection? fileItems = null)
        where T : OrgMonitoring
        {
            var Organization = await _genericRepository.GetByIdAsync<Organization>(report.OrganizationId) 
                               ?? throw new NullReferenceException($"with id={report.OrganizationId} organization not found!");
            
            OrgMonitoringDto Dto = new(Organization.FullName, report.Year, report.QuarterIndex, report.SectionNumber);

            var fileModels = await ProcessMultipleFiles(fileItems, Dto, docInfo);

            // Assign values to navigation properties of the forms 
            // For the navigation propertyless forms, just return report itself
            // Check filmodels emptiness for only the forms requiring file upload

            switch (report)
                {
                    case Form1_1_1:
                    case Form1_1_2:
                    case Form1_1_3:
                    case Form2_1_1:
                    case Form2_1_2:
                    case Form2_2_1:
                    case Form2_3_1:
                    case Form2_3_2:
                        if (fileModels.Count == 0)
                            throw new NotSupportedException($"No files received!");
                        SetFileModelProperty(report, fileModels.First());
                        break;

                    case Form2_2_2:
                        if (fileModels.Count == 0)
                            throw new NotSupportedException($"No files received!");
                    PropertyInfo relatedFiles = report.GetType().GetProperty(nameof(Form2_2_2.FileModels))!;
                        relatedFiles.SetValue(report, fileModels);
                        break;

                    case Form2_8_1:
                        if (fileModels.Count == 0)
                            throw new NotSupportedException($"No files received!");
                    SetPropertyForForm2_8_1(report, fileModels);
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
        private List<ReportResponse> GetPropertiesAndValues(object obj, FormItem[] formItems, int order = 1)
        {
            var response = new List<ReportResponse>();
            
            int Order = order;

            // Get object type properties including parent class properties
            var properties = obj.GetType().GetProperties()
                                    .Where(p => p.GetCustomAttribute<PropertyOrderAttribute>() != null)
                                    .OrderBy(p => p.GetCustomAttribute<PropertyOrderAttribute>()!.Order).ToArray();
            
            // Generate FormItem array for the given object
            var selectedItems = GenerateSelectedItems(properties, formItems);

            /// => FormItems length may not be equal to properties length 
            /// as an object property can be collection of another object connected to multiple form items
            for (int i=0; i<properties.Length; i++)
            {               
                var orderAttr = properties[i].GetCustomAttribute<PropertyOrderAttribute>();

                bool toBeDisplayed = properties[i].GetCustomAttribute<PropertyDisplayAttribute>() != null 
                                        && properties[i].GetCustomAttribute<PropertyDisplayAttribute>()!.Display
                                        || properties[i].GetCustomAttribute<PropertyDisplayAttribute>() == null;

                // if property should be displayed then name it with form item label else just property name
                string propertyLabel = !toBeDisplayed ? properties[i].Name : (selectedItems[i] != null ? selectedItems[i].ItemLabel : string.Empty);

                string itemType = !toBeDisplayed ? string.Empty : (selectedItems[i] != null ? selectedItems[i].FormItemType.TypeName : string.Empty);

                int currentOrder = (order == 1 && orderAttr != null) ? orderAttr.Order : (order != 1 ? Order : int.MaxValue);

                var value = properties[i].GetValue(obj);

                bool isFileWithInfo = itemType.Equals("fileWithInfo");

                // if the form item is a file type with metadata then fetch its metadata
                var fileInfo = isFileWithInfo ? GetFileInfo(value == null ? 0 : (int)value).Result : null;

                // if the object property is a collection (except string) then generate form items list of this collection type object
                if (value is IEnumerable<object> collection && value is not string) // Ensure strings aren't treated as collections
                {
                    var collectionResponses = new List<List<ReportResponse>>();
                    foreach (var item in collection)
                    {
                        collectionResponses.Add(GetPropertiesAndValues(item, formItems, Order)); // Recursive call for collection items
                    }

                    response.Add(new ReportResponse
                    {
                        PropertyLabel = GetTheLabelOfList(formItems),
                        Value = null, // You can decide if you want to include the raw collection here
                        Order = currentOrder,
                        Type = itemType,
                        IsCollection = true,
                        CollectionItems = collectionResponses,
                        ToBeDisplayed = toBeDisplayed
                    });
                }
                else
                {
                    response.Add(new ReportResponse
                    {
                        PropertyLabel = propertyLabel,
                        Value = value,
                        Order = currentOrder,
                        Type = itemType,
                        IsCollection = false,
                        IsFileWithInfo = isFileWithInfo,
                        FileInformation = fileInfo,
                        ToBeDisplayed = toBeDisplayed
                    });
                }

                if (order != 1)
                    Order++;
            }

            return response;

            
        }
        private async Task<object> GetReportDto(ReportRequest reportRequest, object? blockDto)
        {
           
            if(!_formTypeHandlers.ContainsKey(reportRequest.SectionNumber))
            {
                throw new NotSupportedException($"Section number with <{reportRequest.SectionNumber}> not found!");
            }

            return await _formTypeHandlers[reportRequest.SectionNumber](reportRequest, blockDto);
        }
        private static Expression<Func<T, bool>> BuildPredicate<T>(ReportRequest reportRequest) where T : OrgMonitoring
        {
            return entity => entity.Year == reportRequest.Period.Year &&
                             entity.QuarterIndex == reportRequest.Period.Quarter &&
                             entity.OrganizationId == reportRequest.OrganizationId;
        }
        private async Task<object> FetchAndMap<TEntity, TDto>(ReportRequest reportRequest, object? blockDto)
            where TEntity : OrgMonitoring, new()
            where TDto : class, new()
        {
            var predicate = BuildPredicate<TEntity>(reportRequest);
            return await FetchAndMapData<TEntity, TDto>(predicate, blockDto);
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
        private async Task<IEnumerable<FormSection>> GetSectionsByQbId(int qbId)
        {
            return await _genericRepository.GetAllAsync<FormSection>(e => e.QuestionBlockId == qbId);
        }
        private async Task<IEnumerable<Organization>> GetOrganizations(int organizationId)
        {
            if (organizationId == 0)
                return await _genericRepository.GetAllAsync<Organization>();

            var organization = await _genericRepository.GetByIdAsync<Organization>(organizationId);
            return organization != null ? new List<Organization> { organization } : Enumerable.Empty<Organization>();
        }
        private async Task<List<List<ReportResponse>>> BuildFinalResponses(IEnumerable<Organization> organizations, IEnumerable<FormSection> sections, ReportRequestByQb reportRequest)
        {
            List<List<ReportResponse>> finalResponseList = new();

            foreach (var org in organizations)
            {
                List<ReportResponse> responseList = new()
                    {
                        new ReportResponse("Наименование структурных подразделений", org.FullName, true)
                    };

                object? blockDto = null;
                List<FormItem> formItems = new();

                foreach (var section in sections)
                {
                    var report = await GetReportDto(new ReportRequest(section.SectionNumber, org.OrganizationId, reportRequest.Period.Year, reportRequest.Period.Quarter), blockDto);
                    blockDto = report;

                    var items = await _genericRepository.GetAllAsync<FormItem>(
                                    e => e.FormSectionId == section.SectionId && e.ItemName != "FileItem",
                                    query => query.Include(e => e.FormItemType));

                    formItems.AddRange(items);
                }

                var responseObjList = GetPropertiesAndValues(blockDto!, formItems.ToArray());
                responseList.AddRange(responseObjList);

                finalResponseList.Add(responseList);
            }

            return finalResponseList;
        }
        private static void SetFileModelProperty(object targetReport, object value)
        {
            //string propertyName = $"{targetReport.GetType().Name}.FileModel";
            PropertyInfo fileModelProperty = targetReport.GetType().GetProperty("FileModel")!;
            fileModelProperty.SetValue(targetReport, value);
        }
        private static void SetPropertyForForm2_8_1(object targetReport, List<FileModel> fileModelsList)
        {
            PropertyInfo qualificationImprovedEmployeeListProperty = targetReport.GetType().GetProperty(nameof(Form2_8_1.QualificationImprovedEmployees))!;
            List<QualificationImprovedEmployee> qualificationImprovedEmployees = (List<QualificationImprovedEmployee>)
                qualificationImprovedEmployeeListProperty.GetValue(targetReport)!;

            for (int i = 0; i < Math.Min(qualificationImprovedEmployees.Count, fileModelsList.Count); i++)
            {
                qualificationImprovedEmployees[i].Certificate = fileModelsList[i];
            }

            qualificationImprovedEmployeeListProperty.SetValue(targetReport, qualificationImprovedEmployees);
        }
        private static FormItem[] GenerateSelectedItems(PropertyInfo[] properties, FormItem[] formItems)
        {
            FormItem[] SelectedItems = new FormItem[properties.Length];

            // Convert items to a dictionary for faster lookup
            var itemsDict = formItems.ToDictionary(item => item.ItemName, item => item);

            var namesForFileType = new List<string>() {"FileId","FileIds"};

            // Go through Properties and look for property name match in items dictionary and update SelectedItems with them
            foreach (var property in properties.Select((prop, idx) => new { prop, idx }))
            {
                var propertyName = namesForFileType.Any(n => n.Equals(property.prop.Name)) ? "FileItem" : property.prop.Name;

                if (itemsDict.TryGetValue(propertyName, out var foundItem))
                {
                    SelectedItems[property.idx] = foundItem;
                }
            }

            return SelectedItems;
            
        }      
        private static string? GetTheLabelOfList(FormItem[] items)
        {
            // Assuming that there can be only one list items in the array
            foreach (var item in items)
            {
                if (item.IsListItem)
                {
                    return item.ListLabel;
                }
            }

            return string.Empty;
        }    
        private async Task<ReportResponse.FileInfo> GetFileInfo(int id)
        {
            var fileModel = await _genericRepository.GetByIdAsync<FileModel>(id);

            return fileModel == null ? new ReportResponse.FileInfo("", new DateTime())
                                        : new ReportResponse.FileInfo(fileModel.DocNumber, fileModel.DocDate);
        }
        private async Task<Result<int>> GetOrganizationId(int organizationId)
        {
            if(organizationId != 0 && organizationId > 0)
            {
                var isUserAuthorizedResult = await _applicationUserService.IsUserAuthorizedForThisInfo(organizationId);

                if (!isUserAuthorizedResult.Succeeded)
                    return await Result<int>.FailAsync(String.Join(",", isUserAuthorizedResult.Messages));
                if (!isUserAuthorizedResult.Data)
                    return await Result<int>.FailAsync(
                        HttpStatusCode.Unauthorized,
                        new List<string> { $"you are not authorized to get info of organization with id = {organizationId}" });

                return await Result<int>.SuccessAsync(organizationId);
            }

            var claimResult = await _applicationUserService.GetCurrentUserClaim(CustomClaimTypes.OrganizationId);

            if (!claimResult.Succeeded)
            {
                return await Result<int>.FailAsync(String.Join(",", claimResult.Messages));
            }

            organizationId = int.TryParse(claimResult.Data, out var value) ? value : 0;
            if (organizationId == 0)
                return await Result<int>.FailAsync($"Wrong Organizaiton Id : {claimResult.Data}");

            return await Result<int>.SuccessAsync(organizationId);
        }

        #endregion
    }
}
