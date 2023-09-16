using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_15_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsPlannedPrevWorkAvailable { get; init; }
        [PropertyOrder(2)]
        public string? FrequencyOfPrevMaintanence { get; init; }
    }
}
