using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_9Dto
    {
        [PropertyOrder(1)]
        public bool? IsVPNUsed { get; init; }
        [PropertyOrder(2)]
        public string? PurposeAndScopeOfVPNConnections { get; init; }
    }
}
