namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_1_1Dto : BaseFormDto
    {
        public bool? IsActionPlanAvailableToEnsIC { get; set; }
        public string? FileDescription { get; set; } = "Файл";
        public int? FileId { get; set; }
        public string? ReasonForAbsenceOfPlan { get; set; }
    }
}
