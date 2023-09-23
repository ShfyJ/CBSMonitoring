using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_7_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsInstructionPresent { get; init; }
        [PropertyOrder(2)]
        public int? PositionInstructionCount { get; init; }
    }
}
