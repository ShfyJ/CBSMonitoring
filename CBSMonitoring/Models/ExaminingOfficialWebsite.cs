namespace CBSMonitoring.Models
{
    public class ExaminingOfficialWebsite : OrgMonitoring //2.9
    {
        #nullable enable
        public string? WebAddress { get; set; }
        public string? ExpertizingPeriod { get; set; }
        public string? ExpertConclusionNumber { get; set; }
        public DateTime? ExpertConclusionDate { get; set; }
        public bool? HasShortcomings { get; set; }
        public bool? IsShortcomingsEliminated { get; set; }  
    }
}
