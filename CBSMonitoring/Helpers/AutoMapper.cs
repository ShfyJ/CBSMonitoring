using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models.Forms;

namespace CBSMonitoring.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            var map1_1_1 = CreateMap<MonitoringDTO, Form1_1_1>();
            map1_1_1.ForAllMembers(opt => opt.Ignore());
            map1_1_1.ForMember(dest => dest.HasPolicy, opt => opt.MapFrom(src => src.HasPolicy));

            CreateMap<Form1_1_1, MonitoringDTO>()
                .ForMember(dest => dest.HasPolicy, opt => opt.MapFrom(src => src.HasPolicy));
            


        }
    }
}
