using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_12_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsCAndAnalysisToolAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NameAndVersionOfCAndSAnalysisTool { get; init; }
        [PropertyOrder(3)]
        public string? CAToolType { get; init; }
        [PropertyOrder(4)]
        public string? PurposeOfCAndSAnalysisTools { get; init; }
        [PropertyOrder(5)]
        public string? NumberOfCAndSAnalysisTools { get; init; }
    }
}
