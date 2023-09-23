using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_14Dto
    {
        [PropertyOrder(1)]
        public int? NumOfServersWithLicensedOS { get; init; }
        [PropertyOrder(2)]
        public int? NumOfServersWithUpdatingOs { get; init; }
        [PropertyOrder(3)]
        public int? NumOfWRoomswihLicensedOS { get; init; }
    }
}
