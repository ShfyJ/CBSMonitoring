using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_7_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsEXATAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfSystemsWithEXAT { get; init; }
    }
}
