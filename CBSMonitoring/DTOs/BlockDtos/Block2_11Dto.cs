using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_11Dto
    {
        [PropertyOrder(1)]
        public bool? IsEntranceSecurityAvailable { get; init; }
        [PropertyOrder(2)]
        public bool? IsACSAvialble { get; init; }
        [PropertyOrder(3)]
        public bool? IsCheckInOutLogAvailable { get; init; }
        [PropertyOrder(4)]
        public bool? IsSurveillanceCamerasAvailable { get; init; }
        [PropertyOrder(5)]
        public int? NumberOfVideoCamsInTerritorialObjs { get; init; }
        [PropertyOrder(6)]
        public bool? IsSecAlarmsInCentreAvailable { get; init; }
        [PropertyOrder(7)]
        public int? NumberOfRoomsMonitoredByAlarms { get; init; }
        [PropertyOrder(8)]
        public bool? IsServerRoomOrDataCenterAvailable { get; init; }
        [PropertyOrder(9)]
        public int? NumberOfServerRoom { get; init; }
        [PropertyOrder(10)]
        public int? NumberOfDataCentre { get; init; }
        [PropertyOrder(11)]
        public int? NumberOfSRandDCWithMetalDoor { get; init; }
        [PropertyOrder(12)]
        public int? NumberOfSRandDCWithWithSystemControl { get; init; }
        [PropertyOrder(13)]
        public bool? IsCoolingSystemAvailable { get; init; }
        [PropertyOrder(14)]
        public bool? IsAntiFireEquipAvailable { get; init; }
        [PropertyOrder(15)]
        public bool? IsPlanForPreventiveMaintAvailable { get; init; }
        [PropertyOrder(16)]
        public bool? IsVideoCamAvailable { get; init; }
        [PropertyOrder(17)]
        public bool? IsFalseFloorAndCeilingAvailable { get; init; }
        [PropertyOrder(18)]
        public bool? IsTempSensorsAvailable { get; init; }
        [PropertyOrder(19)]
        public bool? IsLogsForSRAndDCEntrance { get; init; }
        [PropertyOrder(20)]
        public int? NumberOfServersWithSealedOuterCases { get; init; }
        [PropertyOrder(21)]
        public int? NumberOfWStWithSealedOuterCases { get; init; }
    }
}
