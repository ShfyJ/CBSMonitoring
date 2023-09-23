using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_10Dto
    {
        [PropertyOrder(1)]
        public bool? IsObjectsAudited { get; init; }
        [PropertyOrder(2)]
        public string? AuditPeriod { get; init; }
        [PropertyOrder(3)]
        public string? NumberOfAuditConc { get; init; }
    }
}
