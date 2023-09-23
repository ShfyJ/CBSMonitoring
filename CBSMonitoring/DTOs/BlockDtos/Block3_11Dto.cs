using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_11Dto
    {
        [PropertyOrder(1)]
        public bool? IsSIEMAvailable { get; init; }
        [PropertyOrder(2)]
        public bool? IsLicenseForSIEMAvailable { get; init; }
    }
}
