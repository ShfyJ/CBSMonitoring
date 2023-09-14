namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_1_2Dto : BaseFormDto
    {
        public bool? IsActionPlanAgreedToEnsIC { get; set; }
        public string? FileDescription { get; set; } = "Файл";
        public int? FileId { get; set; }
        public string? ReasonForAbsenceOfAgreement { get; set; }
    }
}
