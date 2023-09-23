using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_10Dto
    {
        [PropertyOrder(1)]
        public bool? IsDLPAvailable { get; init; }
        [PropertyOrder(2)]
        public bool? IsLicenceOfDLPAvaliable { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfWorkRoomsWithDLP { get; init; }
    }
}
