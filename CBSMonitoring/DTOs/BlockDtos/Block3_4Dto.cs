using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_4Dto
    {
        [PropertyOrder(1)]
        public bool? IsLicenseForAntivirusAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfServersWithAntivirus { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfWRsWithAntivirus { get; init; }
    }
}
