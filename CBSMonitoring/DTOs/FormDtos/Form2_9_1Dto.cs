namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_9_1Dto : BaseFormDto
    {
        public string? WebAddress { get; init; }
        public string? ExpertizingPeriod { get; init; }
        public string? ExpertConclusionNumber { get; init; }
        public DateTime? ExpertConclusionDate { get; init; }
        public bool? HasShortcomings { get; init; }
        public bool? IsShortcomingsOfWebsiteEliminated { get; init; }
    }
}
