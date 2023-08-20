namespace CBSMonitoring.Models.Forms
{
    public class Form2_9_1 : OrgMonitoring //2.9
    {
        public string? WebAddress { get; set; }
        public string? ExpertizingPeriod { get; set; }
        public string? ExpertConclusionNumber { get; set; }
        public DateTime? ExpertConclusionDate { get; set; }
        public bool? HasShortcomings { get; set; }
        public bool? IsShortcomingsOfWebsiteEliminated { get; set; }
    }
}
