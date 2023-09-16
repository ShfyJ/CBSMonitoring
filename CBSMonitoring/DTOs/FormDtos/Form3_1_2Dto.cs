using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_1_2Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsPasswProtectInSRsAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfSRsWithPasswProtection { get; init; }
        [PropertyOrder(3)]
        public string? FrequncyOfPasswUpdateInSRs { get; init; }
    }
}
