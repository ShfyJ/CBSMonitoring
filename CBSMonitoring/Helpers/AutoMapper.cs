using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.DTOs.FormDtos;
using CBSMonitoring.Model;
using CBSMonitoring.Models;
using CBSMonitoring.Models.Forms;
using Microsoft.AspNetCore.Routing.Constraints;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Helpers
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
            #region Monitoring Indicator

            CreateMap<MonitoringIndicator, MonitoringIndicatorWithQbsResponse>()
                .ForMember(dest => dest.QuestionBlocks, opt => opt.MapFrom(src => src.QuestionBlocks));
            CreateMap<MonitoringIndicator, MonitoringIndicatorResponse>()
                .ForMember(dest => dest.QbCount, opt => opt.MapFrom(src => src.QuestionBlocks == null ? 0 : src.QuestionBlocks.Count));
            
            /*</> Some other conditional mapping options -->
            CreateMap<MonitoringIndicator, MonitoringIndicatorResponse>()
                .ForMember(dest => dest.QbCount, opt => opt.MapFrom((src, dest) => src.QuestionBlocks?.Count ?? 0));
            CreateMap<MonitoringIndicator, MonitoringIndicatorResponse>()
                .ForMember(dest => dest.QbCount, opt => opt.MapFrom(src => MapQbCount(src))); */

            #endregion

            #region Organization

            CreateMap<OrganizationRequest, Organization>();
            CreateMap<Organization, OrganizationResponse>();
            
            #endregion

            #region TimeExecutionOfPlan

            CreateMap<TimelyExecutionOfPlanRequest, TimelyExecutionOfPlan>();
            CreateMap<TimelyExecutionOfPlan,  TimelyExecutionOfPlanResponse>();

            #endregion

            #region QualificationImprovedEmployee

            CreateMap<QualificationImprovedEmployeeRequest, QualificationImprovedEmployee>();
            CreateMap<QualificationImprovedEmployee, QualificationImprovedEmployeeResponse>();

            #endregion
            
            #region Form Item Type
            CreateMap<FormItemTypeRequest, FormItemType>()
                .ForMember(dest => dest.TypeId, opt => opt.Ignore());
            #endregion

            #region Form Item
            CreateMap<FormItemRequest, FormItem>();

            #endregion

            #region Form Section
            CreateMap<FormSectionRequest, FormSection>();
            CreateMap<FormSection, FormSectionResponse>();
            #endregion

            #region FileModel
            CreateMap<FileModel, FileModel>()
                .ForMember(dest => dest.FileId, opt => opt.Ignore())
                .ForMember(dest => dest.Form2_2_2Id, opt => opt.Ignore());
            #endregion

            #region Question Block
            CreateMap<QuestionBlockRequest, QuestionBlock>();
            CreateMap<QuestionBlock, QuestionBlockResponse>()
                .ForMember(dest => dest.SectionCount, opt => opt.MapFrom(src => src.FormSections.Count));
            #endregion

            #region Form 1.1.1
            CreateMap<MonitoringDto, Form1_1_1>();
            CreateMap<Form1_1_1, Form1_1_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())
                .ForMember(dest => dest.File_1_1_1Id, opt => opt.Ignore())
                .ForMember(dest => dest.FileModel, opt =>
                {
                    opt.PreCondition(src => src.FileModel != null);
                });

            CreateMap<Form1_1_1, Form1_1_1Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_1_1_1Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.FullName));
            #endregion

            #region Form 1.1.2
            CreateMap<MonitoringDto, Form1_1_2>();
            CreateMap<Form1_1_2, Form1_1_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())
                .ForMember(dest => dest.File_1_1_2Id, opt => opt.Ignore())
                .ForMember(dest => dest.FileModel, opt =>
                {
                    opt.PreCondition(src => src.FileModel != null);
                });

            CreateMap<Form1_1_2, Form1_1_2Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_1_1_2Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.FullName));
            #endregion

            #region Form 1.1.3
            CreateMap<MonitoringDto, Form1_1_3>();
            CreateMap<Form1_1_3, Form1_1_3>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())
                .ForMember(dest => dest.File_1_1_3Id, opt => opt.Ignore())
                .ForMember(dest => dest.FileModel, opt =>
                {
                    opt.PreCondition(src => src.FileModel != null);
                });

            CreateMap<Form1_1_3, Form1_1_3Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_1_1_3Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.FullName));

            #endregion

            #region Form 1.1.4
            CreateMap<MonitoringDto, Form1_1_4>();
            CreateMap<Form1_1_4, Form1_1_4Dto>();
            #endregion

            #region Form 1.1.5
            CreateMap<MonitoringDto, Form1_1_5>();
            CreateMap<Form1_1_5, Form1_1_5Dto>();
            #endregion

            #region Form 1.1.6
            CreateMap<MonitoringDto, Form1_1_6>();
            CreateMap<Form1_1_6, Form1_1_6Dto>();
            #endregion

            #region Form 2.1.1
            CreateMap<MonitoringDto, Form2_1_1>();
            CreateMap<Form2_1_1, Form2_1_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())
                .ForMember(dest => dest.File_2_1_1Id, opt => opt.Ignore())
                .ForMember(dest => dest.FileModel, opt =>
                {
                    opt.PreCondition(src => src.FileModel != null);
                });

            CreateMap<Form2_1_1, Form2_1_1Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_2_1_1Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.FullName));
            #endregion

            #region Form 2.1.2
            CreateMap<MonitoringDto, Form2_1_2>();
            CreateMap<Form2_1_2, Form2_1_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())
                .ForMember(dest => dest.File_2_1_2Id, opt => opt.Ignore())
                .ForMember(dest => dest.FileModel, opt =>
                {
                    opt.PreCondition(src => src.FileModel != null);
                });

            CreateMap<Form2_1_2, Form2_1_2Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_2_1_2Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.FullName));
            #endregion

            #region Form 2.2.1
            CreateMap<MonitoringDto, Form2_2_1>();
            CreateMap<Form2_2_1, Form2_2_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())
                .ForMember(dest => dest.File_2_2_1Id, opt => opt.Ignore())
                .ForMember(dest => dest.FileModel, opt =>
                {
                    opt.PreCondition(src => src.FileModel != null);
                });

            CreateMap<Form2_2_1, Form2_2_1Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_2_2_1Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.FullName));
            #endregion

            #region Form 2.2.2

            CreateMap<MonitoringDto, Form2_2_2>()
                .ForMember(
                    dest => dest.TimelyExecutionOfPlans,
                    opt => opt.MapFrom(src => src.TimelyExecutionOfPlans));
            CreateMap<Form2_2_2, Form2_2_2Dto>()
                .ForMember(dest => dest.ResponseList, opt => opt.MapFrom(src => src.TimelyExecutionOfPlans))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.FullName))
                .AfterMap((src, dest) =>
                {
                    List<int> ids = new();

                    if(src.FileModels != null)
                        
                        foreach(var file in src.FileModels)
                        {
                            ids.Add(file.FileId);
                        }

                    dest.FileIds = ids;
                });
            #endregion

            #region Form 2.3.1
            CreateMap<MonitoringDto, Form2_3_1>();
            CreateMap<Form2_3_1, Form2_3_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())
                .ForMember(dest => dest.File_2_3_1Id, opt => opt.Ignore())
                .ForMember(dest => dest.FileModel, opt =>
                {
                    opt.PreCondition(src => src.FileModel != null);
                });

            CreateMap<Form2_3_1, Form2_3_1Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_2_3_1Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.FullName));
            #endregion

            #region Form 2.3.2
            CreateMap<MonitoringDto, Form2_3_2>();
            CreateMap<Form2_3_2, Form2_3_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())
                .ForMember(dest => dest.File_2_3_2Id, opt => opt.Ignore())
                .ForMember(dest => dest.FileModel, opt =>
                {
                    opt.PreCondition(src => src.FileModel != null);
                });

            CreateMap<Form2_3_2, Form2_3_2Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_2_3_2Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.FullName));
            #endregion
            
            #region Form 2.8.1

            //CreateMap<MonitoringDto, Form2_8_1>();
            CreateMap<MonitoringDto, Form2_8_1>()
                .ForMember(
                    dest => dest.QualificationImprovedEmployees,
                    opt => opt.MapFrom(src => src.QualificationImprovedEmployees));
            CreateMap<Form2_8_1, Form2_8_1Dto>()
                .ForMember(
                    dest => dest.QualificationImprovedEmployees,
                    opt => opt.MapFrom(src => src.QualificationImprovedEmployees))
                .ForMember(
                    dest => dest.OrganizationName,
                    opt => opt.MapFrom(src => src.Organization.FullName));

            #endregion
            
           
        }
    }
}
