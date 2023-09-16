using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_4_2Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsDevisionPositionPresent { get; init; }
        [PropertyOrder(2)]
        public string? SectionHeadFullName { get; init; }
        [PropertyOrder(3)]
        public string? PositionOfSectionHead { get; init; }
        [PropertyOrder(4)]
        public string? PhoneNumOfSectionHead { get; init; }
        [PropertyOrder(5)]
        public string? EmailOfSectionHead { get; init; }
        [PropertyOrder(6)]
        public int? NumberOfISEmployees { get; init; }
    }
}
