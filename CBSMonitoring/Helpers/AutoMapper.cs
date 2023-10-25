using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.DTOs.BlockDtos;
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
            #region user update

            CreateMap<UserUpdateRequest, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.Ignore());

            CreateMap<UserSelfUpdateRequest, ApplicationUser>();

            #endregion

            #region Evaluation
            CreateMap<EvaluationRequest, Evaluation>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year))
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter));

            CreateMap<Evaluation, Evaluation>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Evaluation, ScoreResponse>()
                .ConstructUsing(src => new ScoreResponse(
                    src.BlockNumber,
                    src.Score,
                    src.EvaluatedTime,
                    src.Comment,
                    true, null)) // you can adjust this according to your needs
                .ForMember(dest => dest.Discriminator, opt => opt.MapFrom(src => src.BlockNumber))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
                .ForMember(dest => dest.EvaluatedTime, opt => opt.MapFrom(src => src.EvaluatedTime))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));

            CreateMap<IEnumerable<Evaluation>, IEnumerable<ScoreResponse>>();
            CreateMap<ReEvaluationRequest, Evaluation>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion

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
            CreateMap<QualificationImprovedEmployee, QualificationImprovedEmployeeResponse>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.CertificateFileId));
            CreateMap<QualificationImprovedEmployee, QualificationImprovedEmployee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CertificateFileId, opt => opt.Ignore())
                .ForMember(dest => dest.Certificate, opt => opt.MapFrom(src => src.Certificate))
                .ForPath(dest => dest.Certificate.FileId, opt => opt.Ignore());
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
            CreateMap<QuestionBlock, RawQuestionBlockResponse>()
                .ForMember(dest => dest.SectionCount, opt => opt.MapFrom(src => src.FormSections.Count));
            #endregion

            #region Forms

            #region Form 1.1.1
            CreateMap<MonitoringDto, Form1_1_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
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
            CreateMap<MonitoringDto, Form1_1_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
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
            CreateMap<MonitoringDto, Form1_1_3>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
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
            CreateMap<MonitoringDto, Form1_1_4>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_1_4, Form1_1_4Dto>();
            CreateMap<Form1_1_4, Form1_1_4>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.1.5
            CreateMap<MonitoringDto, Form1_1_5>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_1_5, Form1_1_5Dto>();
            CreateMap<Form1_1_5, Form1_1_5>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.1.6
            CreateMap<MonitoringDto, Form1_1_6>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_1_6, Form1_1_6Dto>();
            CreateMap<Form1_1_6, Form1_1_6>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.2.1
            CreateMap<MonitoringDto, Form1_2_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_2_1, Form1_2_1Dto>();
            CreateMap<Form1_2_1, Form1_2_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.3.1
            CreateMap<MonitoringDto, Form1_3_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_3_1, Form1_3_1Dto>();
            CreateMap<Form1_3_1, Form1_3_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.4.1
            CreateMap<MonitoringDto, Form1_4_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_4_1, Form1_4_1Dto>();
            CreateMap<Form1_4_1, Form1_4_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.4.2
            CreateMap<MonitoringDto, Form1_4_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_4_2, Form1_4_2Dto>();
            CreateMap<Form1_4_2, Form1_4_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.4.3
            CreateMap<MonitoringDto, Form1_4_3>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_4_3, Form1_4_3Dto>();
            CreateMap<Form1_4_3, Form1_4_3>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.4.4
            CreateMap<MonitoringDto, Form1_4_4>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_4_4, Form1_4_4Dto>();
            CreateMap<Form1_4_4, Form1_4_4>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.5.1
            CreateMap<MonitoringDto, Form1_5_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_5_1, Form1_5_1Dto>();
            CreateMap<Form1_5_1, Form1_5_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.5.2
            CreateMap<MonitoringDto, Form1_5_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_5_2, Form1_5_2Dto>();
            CreateMap<Form1_5_2, Form1_5_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 1.5.3
            CreateMap<MonitoringDto, Form1_5_3>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form1_5_3, Form1_5_3Dto>();
            CreateMap<Form1_5_3, Form1_5_3>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 2.1.1
            CreateMap<MonitoringDto, Form2_1_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
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
            CreateMap<MonitoringDto, Form2_1_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
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
            CreateMap<MonitoringDto, Form2_2_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
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
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year))
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
            CreateMap<MonitoringDto, Form2_3_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
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
            CreateMap<MonitoringDto, Form2_3_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
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

            #region Form 2.3.3
            CreateMap<MonitoringDto, Form2_3_3>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_3_3, Form2_3_3Dto>();
            CreateMap<Form2_3_3, Form2_3_3>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore());
            #endregion

            #region Form 2.3.4
            CreateMap<MonitoringDto, Form2_3_4>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_3_4, Form2_3_4Dto>();
            CreateMap<Form2_3_4, Form2_3_4>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.4.1
            CreateMap<MonitoringDto, Form2_4_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_4_1, Form2_4_1Dto>();
            CreateMap<Form2_4_1, Form2_4_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.4.2
            CreateMap<MonitoringDto, Form2_4_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_4_2, Form2_4_2Dto>();
            CreateMap<Form2_4_2, Form2_4_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.4.3
            CreateMap<MonitoringDto, Form2_4_3>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_4_3, Form2_4_3Dto>();
            CreateMap<Form2_4_3, Form2_4_3>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.5.1
            CreateMap<MonitoringDto, Form2_5_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_5_1, Form2_5_1Dto>();
            CreateMap<Form2_5_1, Form2_5_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.6.1
            CreateMap<MonitoringDto, Form2_6_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_6_1, Form2_6_1Dto>();
            CreateMap<Form2_6_1, Form2_6_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.7.1
            CreateMap<MonitoringDto, Form2_7_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_7_1, Form2_7_1Dto>();
            CreateMap<Form2_7_1, Form2_7_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.8.1

            //CreateMap<MonitoringDto, Form2_8_1>();
            CreateMap<MonitoringDto, Form2_8_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year))
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
            CreateMap<Form2_8_1, Form2_8_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore())               
                .ForMember(dest => dest.QualificationImprovedEmployees, opt => opt.MapFrom(src => src.QualificationImprovedEmployees));
            #endregion

            #region Form 2.9.1
            CreateMap<MonitoringDto, Form2_9_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_9_1, Form2_9_1Dto>();
            CreateMap<Form2_9_1, Form2_9_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.10.1
            CreateMap<MonitoringDto, Form2_10_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_10_1, Form2_10_1Dto>();
            CreateMap<Form2_10_1, Form2_10_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.11.1
            CreateMap<MonitoringDto, Form2_11_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_11_1, Form2_11_1Dto>();
            CreateMap<Form2_11_1, Form2_11_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.11.2
            CreateMap<MonitoringDto, Form2_11_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_11_2, Form2_11_2Dto>();
            CreateMap<Form2_11_2, Form2_11_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.11.3
            CreateMap<MonitoringDto, Form2_11_3>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_11_3, Form2_11_3Dto>();
            CreateMap<Form2_11_3, Form2_11_3>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.11.4
            CreateMap<MonitoringDto, Form2_11_4>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_11_4, Form2_11_4Dto>();
            CreateMap<Form2_11_4, Form2_11_4>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.11.5
            CreateMap<MonitoringDto, Form2_11_5>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_11_5, Form2_11_5Dto>();
            CreateMap<Form2_11_5, Form2_11_5>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.11.6
            CreateMap<MonitoringDto, Form2_11_6>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_11_6, Form2_11_6Dto>();
            CreateMap<Form2_11_6, Form2_11_6>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.11.7
            CreateMap<MonitoringDto, Form2_11_7>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_11_7, Form2_11_7Dto>();
            CreateMap<Form2_11_7, Form2_11_7>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.12.1
            CreateMap<MonitoringDto, Form2_12_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_12_1, Form2_12_1Dto>();
            CreateMap<Form2_12_1, Form2_12_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.13.1
            CreateMap<MonitoringDto, Form2_13_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_13_1, Form2_13_1Dto>();
            CreateMap<Form2_13_1, Form2_13_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.14.1
            CreateMap<MonitoringDto, Form2_14_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_14_1, Form2_14_1Dto>();
            CreateMap<Form2_14_1, Form2_14_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.15.1
            CreateMap<MonitoringDto, Form2_15_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_15_1, Form2_15_1Dto>();
            CreateMap<Form2_15_1, Form2_15_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.16.1
            CreateMap<MonitoringDto, Form2_16_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_16_1, Form2_16_1Dto>();
            CreateMap<Form2_16_1, Form2_16_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.17.1
            CreateMap<MonitoringDto, Form2_17_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_17_1, Form2_17_1Dto>();
            CreateMap<Form2_17_1, Form2_17_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 2.18.1
            CreateMap<MonitoringDto, Form2_18_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form2_18_1, Form2_18_1Dto>();
            CreateMap<Form2_18_1, Form2_18_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.1.1
            CreateMap<MonitoringDto, Form3_1_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_1_1, Form3_1_1Dto>();
            CreateMap<Form3_1_1, Form3_1_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.1.2
            CreateMap<MonitoringDto, Form3_1_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_1_2, Form3_1_2Dto>();
            CreateMap<Form3_1_2, Form3_1_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.2.1
            CreateMap<MonitoringDto, Form3_2_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_2_1, Form3_2_1Dto>();
            CreateMap<Form3_2_1, Form3_2_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.2.2
            CreateMap<MonitoringDto, Form3_2_2>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_2_2, Form3_2_2Dto>();
            CreateMap<Form3_2_2, Form3_2_2>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.3.1
            CreateMap<MonitoringDto, Form3_3_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_3_1, Form3_3_1Dto>();
            CreateMap<Form3_3_1, Form3_3_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.4.1
            CreateMap<MonitoringDto, Form3_4_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_4_1, Form3_4_1Dto>();
            CreateMap<Form3_4_1, Form3_4_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.5.1
            CreateMap<MonitoringDto, Form3_5_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_5_1, Form3_5_1Dto>();
            CreateMap<Form3_5_1, Form3_5_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.6.1
            CreateMap<MonitoringDto, Form3_6_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_6_1, Form3_6_1Dto>();
            CreateMap<Form3_6_1, Form3_6_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.7.1
            CreateMap<MonitoringDto, Form3_7_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_7_1, Form3_7_1Dto>();
            CreateMap<Form3_7_1, Form3_7_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.8.1
            CreateMap<MonitoringDto, Form3_8_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_8_1, Form3_8_1Dto>();
            CreateMap<Form3_8_1, Form3_8_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.9.1
            CreateMap<MonitoringDto, Form3_9_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_9_1, Form3_9_1Dto>();
            CreateMap<Form3_9_1, Form3_9_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.10.1
            CreateMap<MonitoringDto, Form3_10_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_10_1, Form3_10_1Dto>();
            CreateMap<Form3_10_1, Form3_10_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.11.1
            CreateMap<MonitoringDto, Form3_11_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_11_1, Form3_11_1Dto>();
            CreateMap<Form3_11_1, Form3_11_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.12.1
            CreateMap<MonitoringDto, Form3_12_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_12_1, Form3_12_1Dto>();
            CreateMap<Form3_12_1, Form3_12_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #region Form 3.13.1
            CreateMap<MonitoringDto, Form3_13_1>()
                .ForMember(dest => dest.QuarterIndex, opt => opt.MapFrom(src => src.Period.Quarter))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Period.Year));
            CreateMap<Form3_13_1, Form3_13_1Dto>();
            CreateMap<Form3_13_1, Form3_13_1>()
                .ForMember(dest => dest.MonitoringId, opt => opt.Ignore()); ;
            #endregion

            #endregion

            #region Blocks

            #region Block 1.1
            CreateMap<Form1_1_1, Block1_1Dto>();
            CreateMap<Form1_1_2, Block1_1Dto>();
            CreateMap<Form1_1_3, Block1_1Dto>(); 
            CreateMap<Form1_1_4, Block1_1Dto>();
            CreateMap<Form1_1_5, Block1_1Dto>();
            CreateMap<Form1_1_6, Block1_1Dto>();
            #endregion

            #region Block 1.2
            CreateMap<Form1_2_1, Block1_2Dto>();
            #endregion

            #region Block 1.3
            CreateMap<Form1_3_1, Block1_3Dto>();
            #endregion

            #region Block 1.4
            CreateMap<Form1_4_1, Block1_4Dto>();
            CreateMap<Form1_4_2, Block1_4Dto>();
            CreateMap<Form1_4_3, Block1_4Dto>();
            CreateMap<Form1_4_4, Block1_4Dto>();
            #endregion

            #region Block 1.5
            CreateMap<Form1_5_1, Block1_5Dto>();
            CreateMap<Form1_5_2, Block1_5Dto>();
            CreateMap<Form1_5_3, Block1_5Dto>();
            #endregion

            #region Block 2.1
            CreateMap<Form2_1_1, Block2_1Dto>();
            CreateMap<Form2_1_2, Block2_1Dto>();
            #endregion

            #region Block 2.2
            CreateMap<Form2_2_1, Block2_2Dto>();
            CreateMap<Form2_2_2, Block2_2Dto>();
            #endregion

            #region Block 2.3
            CreateMap<Form2_3_1, Block2_3Dto>();
            CreateMap<Form2_3_2, Block2_3Dto>();
            CreateMap<Form2_3_3, Block2_3Dto>();
            CreateMap<Form2_3_4, Block2_3Dto>();
            #endregion

            #region Block 2.4
            CreateMap<Form2_4_1, Block2_4Dto>();
            CreateMap<Form2_4_2, Block2_4Dto>();
            CreateMap<Form2_4_3, Block2_4Dto>();
            #endregion

            #region Block 2.5
            CreateMap<Form2_5_1, Block2_5Dto>();
            #endregion

            #region Block 2.6
            CreateMap<Form2_6_1, Block2_6Dto>();
            #endregion

            #region Block 2.6
            CreateMap<Form2_6_1, Block2_6Dto>();
            #endregion

            #region Block 2.7
            CreateMap<Form2_7_1, Block2_7Dto>();
            #endregion

            #region Block 2.8
            CreateMap<Form2_8_1, Block2_8Dto>();
            #endregion

            #endregion
        }
    }
}
