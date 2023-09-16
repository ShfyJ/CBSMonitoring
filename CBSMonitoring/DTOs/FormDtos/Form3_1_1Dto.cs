using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_1_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsPasswProtectInWRsAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfWRsWithPasswProtection { get; init; }
        [PropertyOrder(3)]
        public string? FrequencyOfPasswUpdateInWRs { get; init; }
    }
}
