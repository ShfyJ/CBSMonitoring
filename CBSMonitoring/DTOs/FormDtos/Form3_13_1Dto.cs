using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_13_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsProtectionToolAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NameOfProtectionTool { get; init; }
        [PropertyOrder(3)]
        public string? ProtectionToolType { get; init; }
        [PropertyOrder(4)]
        public string? PurposeOfProtectionTool { get; init; }
        [PropertyOrder(5)]
        public int? NumberOfProtectionTool { get; init; }
    }
}
