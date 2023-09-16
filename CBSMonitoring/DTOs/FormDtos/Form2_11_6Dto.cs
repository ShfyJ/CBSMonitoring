using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_11_6Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsServerRoomOrDataCenterAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfServerRoom { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfDataCentre { get; init; }
        [PropertyOrder(4)]
        public int? NumberOfSRandDCWithMetalDoor { get; init; }
        [PropertyOrder(5)]
        public int? NumberOfSRandDCWithWithSystemControl { get; init; }
        [PropertyOrder(6)]
        public bool? IsCoolingSystemAvailable { get; init; }
        [PropertyOrder(7)]
        public bool? IsAntiFireEquipAvailable { get; init; }
        [PropertyOrder(8)]
        public bool? IsPlanForPreventiveMaintAvailable { get; init; }
        [PropertyOrder(9)]
        public bool? IsVideoCamAvailable { get; init; }
        [PropertyOrder(10)]
        public bool? IsFalseFloorAndCeilingAvailable { get; init; }
        [PropertyOrder(11)]
        public bool? IsTempSensorsAvailable { get; init; }
        [PropertyOrder(12)]
        public bool? IsLogsForSRAndDCEntrance { get; init; }
    }
}
