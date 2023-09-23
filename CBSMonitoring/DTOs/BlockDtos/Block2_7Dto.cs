using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_7Dto
    {
        [PropertyOrder(1)]
        public bool? IsInstructionPresent { get; init; }
        [PropertyOrder(2)]
        public int? PositionInstructionCount { get; init; }
    }
}
