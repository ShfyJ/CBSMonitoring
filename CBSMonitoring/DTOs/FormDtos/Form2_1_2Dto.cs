using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_1_2Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsActionPlanAgreedToEnsIC { get; set; }
        [PropertyOrder(2)]
        public int? FileId { get; set; }
        [PropertyOrder(2)]
        public string? ReasonForAbsenceOfAgreement { get; set; }
    }
}
