using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_15Dto
    {
        [PropertyOrder(1)]
        public bool? IsPlannedPrevWorkAvailable { get; init; }
        [PropertyOrder(2)]
        public string? FrequencyOfPrevMaintanence { get; init; }
    }
}
