namespace CBSMonitoring.Models
{
    public class AvailablityOfControlsAndSecurityAnalysis : OrgMonitoring //3.12
    {
        public string? NameAndVersionOfCAndSAnalysisTool { get; set; }  
        public string? PurposeOfCAndSAnalysisTools { get;set; }
        public string? NumberOfCAndSAnalysisTools { get; set; }

    }
}
