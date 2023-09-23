using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_5Dto
    {
        [PropertyOrder(1)]
        public bool? IsFirewallAvailable { get; init; }
        [PropertyOrder(2)]
        public bool? IsLicenceForFireWallAvailable { get; init; }
    }
}
