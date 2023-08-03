namespace CBSMonitoring.Models
{
    public class ResponsiblePersonForSecIssues : OrgMonitoring //2.6
    {
        public bool? IsRespPersonAvailableForSecIssues { get; set; }
        public string? FullNameOfRespPersonForSecIssues { get; set; }
        public string? PositionOfRespPersonForSecIssues { get; set; }
        public string? TelNumberOfRespPersonForSecIssues { get; set; }
        public string? EmailOfRespPersonForSecIssues { get; set; }
    }
}
