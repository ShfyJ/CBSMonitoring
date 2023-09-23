using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_9_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public string? WebAddress { get; init; }
        [PropertyOrder(2)]
        public string? ExpertizingPeriod { get; init; }
        [PropertyOrder(3)]
        public string? ExpertConclusionNumber { get; init; }
        [PropertyOrder(4)]
        public DateTime? ExpertConclusionDate { get; init; }
        [PropertyOrder(5)]
        public bool? HasShortcomings { get; init; }
        [PropertyOrder(6)]
        public bool? IsShortcomingsOfWebsiteEliminated { get; init; }
    }
}
