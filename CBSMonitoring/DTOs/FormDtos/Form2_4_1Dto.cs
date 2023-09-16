using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_4_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsISecDivisionPresent { get; init; }
        [PropertyOrder(2)]
        public string? ISsecDivisionName { get; init; }
    }
}
