using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_6_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsRespPersonAvailableForSecIssues { get; init; }
        [PropertyOrder(2)]
        public string? FullNameOfRespPersonForSecIssues { get; init; }
        [PropertyOrder(3)]
        public string? PositionOfRespPersonForSecIssues { get; init; }
        [PropertyOrder(4)]
        public string? TelNumberOfRespPersonForSecIssues { get; init; }
        [PropertyOrder(5)]
        public string? EmailOfRespPersonForSecIssues { get; init; }
    }
}
