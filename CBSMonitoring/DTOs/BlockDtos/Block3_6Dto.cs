using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_6Dto
    {
        [PropertyOrder(1)]
        public bool? IsIDPSAvailable { get; init; }
        [PropertyOrder(2)]
        public bool? IsLicenseForIDPSAvailable { get; init; }
    }
}
