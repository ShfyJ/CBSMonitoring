using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_16_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsRecoveryPlansAvailable { get; set; }
    }
}
