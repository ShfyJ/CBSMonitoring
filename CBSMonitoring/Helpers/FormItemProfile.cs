using AutoMapper;
using CBSMonitoring.Models;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Helpers
{
    public class FormItemProfile : Profile
    {
        public FormItemProfile()
            => CreateMap<FormItem, FormItemResponse>()
                .ForCtorParam(ctorParamName: "ItemTypeName", act => act.MapFrom(src => src.FormItemType.TypeName));
    }
}
