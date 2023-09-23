using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_8Dto
    {
        [PropertyOrder(1)]
        public bool? IsHUMOAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfsystemsWithHUMO { get; init; }
    }
}
