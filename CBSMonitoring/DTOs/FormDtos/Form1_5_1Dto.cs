using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_5_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsAgreementOnPrivacyAvailable { get; init; }
    }
}
