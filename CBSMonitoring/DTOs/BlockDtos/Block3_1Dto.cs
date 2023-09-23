using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_1Dto
    {
        [PropertyOrder(1)]
        public int? NumberOfWRsWithPasswProtection { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfSRsWithPasswProtection { get; init; }
    }

}
