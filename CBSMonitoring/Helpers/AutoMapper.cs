using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.DTOs.FormDtos;
using CBSMonitoring.Models;
using CBSMonitoring.Models.Forms;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Helpers
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
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

            #region Question Block
            CreateMap<QuestionBlockRequest, QuestionBlock>();
            CreateMap<QuestionBlock, QuestionBlockResponse>();
            #endregion

            #region Form 1.1.1
            CreateMap<MonitoringDto, Form1_1_1>().ReverseMap();
            CreateMap<Form1_1_1, Form1_1_1Dto>()
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(e => e.File_1_1_1Id))
                .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(e => e.Organization.OrganizationName));
            #endregion

            #region Form 1.1.2
            CreateMap<MonitoringDto, Form1_1_2>().ReverseMap();
            #endregion

            #region Form 1.1.3
            CreateMap<MonitoringDto, Form1_1_3>().ReverseMap();

            #endregion

            #region Form 1.1.4
            CreateMap<MonitoringDto, Form1_1_4>().ReverseMap();
            #endregion

            #region Form 1.1.5
            CreateMap<MonitoringDto, Form1_1_5>().ReverseMap();
            #endregion

            #region Form 1.1.6
            CreateMap<MonitoringDto, Form1_1_6>().ReverseMap();
            #endregion

            #region Form 2.1.1
            CreateMap<MonitoringDto, Form2_1_1>().ReverseMap();
            #endregion

            #region Form 2.1.2
            CreateMap<MonitoringDto, Form2_1_2>().ReverseMap();
            #endregion

            #region Form 2.2.1
            CreateMap<MonitoringDto, Form2_2_1>().ReverseMap();
            #endregion

            #region Form 2.2.2
            CreateMap<MonitoringDto, Form2_2_2>().ReverseMap();

            CreateMap<MonitoringDto, Form2_2_2>()
                .ForMember(
                    dest => dest.TimelyExecutionOfPlans,
                    opt => opt.MapFrom(src => src.TimelyExecutionOfPlans));

            #endregion
        }
    }
}
