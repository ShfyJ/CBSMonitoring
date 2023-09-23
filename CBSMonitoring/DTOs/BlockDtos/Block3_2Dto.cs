using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_2Dto
    {
        [PropertyOrder(1)]
        public bool? IsACToNetInCentreAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumOfOrgsWithACToNetInStrucDiv { get; init; }
    }
}
