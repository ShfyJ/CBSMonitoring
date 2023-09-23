using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_7Dto
    {
        [PropertyOrder(1)]
        public bool? IsEXATAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfSystemsWithEXAT { get; init; }
    }
}
