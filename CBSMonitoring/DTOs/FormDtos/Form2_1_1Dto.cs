using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_1_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsActionPlanAvailableToEnsIC { get; set; }
        [PropertyOrder(2)]
        public int? FileId { get; set; }
        [PropertyOrder(2)]
        public string? ReasonForAbsenceOfPlan { get; set; }
    }
}
