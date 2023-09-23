using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block3_3Dto
    {
        [PropertyOrder(1)]
        public int? NumberOfISWithACS { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfISWithOnlyPassw { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfISWithCryptKeys { get; init; }
        [PropertyOrder(4)]
        public int? NumberOfISWithConfInfUsingACS { get; init; }
        [PropertyOrder(5)]
        public int? NumberOfISWithConfInfWithOnlyPassw { get; init; }
        [PropertyOrder(6)]
        public int? NumberOfISWithConfInfWithCryptKeys { get; init; }
    }
}
