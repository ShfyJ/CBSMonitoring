namespace CBSMonitoring.Models
{
    public class AvailablityOfControlsAndSecurityAnalysis : OrgMonitoring
    {
        public string? NameAndVersionOfCAndSAnalysisTool { get; set; }  
        public string? PurposeOfCAndSAnalysisTools { get;set; }
        public string? NumberOfCAndSAnalysisTools { get; set; }

    }
}
