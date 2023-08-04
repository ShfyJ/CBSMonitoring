namespace CBSMonitoring.Models
{
    public class MeasuresForPhysicalProtection : OrgMonitoring //2.11
    {
        public bool? IsEntranceSecurityAvailable { get; set; }
        public int? NumberOfObjWithSecurity { get; set; }
        public bool? IsACSAvialble { get; set; }
        public int? NumberOfObjInACS { get; set; }
        public bool? IsCheckInOutLogAvailable { get; set; }
        public int? NumberOfPointsInLog { get; set; }
        public bool? IsSurveillanceCamerasAvailable { get; set; }
        public int? NumberOfVideoCamsInCentre { get; set; }
        public int? NumberOfStructObjsWithCams { get; set; }    
        public int? NumberOfVideoCamsInTerritorialObjs { get; set; }
        public bool? AvailabilityOfSecAlarmsInCentre { get; set; }
        public int? NumberOfRoomsMonitoredByAlarms { get; set; }
        public int? NumberOfTerritObjsWithAlarms { get; set; }
        public bool? IsServerRoomAvailable { get; set; }
        public int? NumberOfServerRoom { get; set; }
        public bool? IsDataCentreAvailable { get; set; }
        public int? NumberOfDataCentre { get; set; }
        public int? NumberOfSRandDCWithMetalDoor { get; set; }
        public int? NumberOfSRandDCWithWithSystemControl { get; set; }
        public bool? IsCoolingSystemAvailable { get; set; }
        public bool? IsAntiFireEquipAvailable { get; set; }
        public bool? IsPlanForPreventiveMaintAvailable { get; set; }
        public bool? AvailabilityOfVideoCamInServerRoom { get; set; }
        public bool? AvailablityOfFalseFloorAndCeiling { get; set; }    
        public bool? AvailablityOfTempSensors { get; set; }
        public bool? AvailablityOfLogsForServerRoomEntrance { get; set; }
        public int? NumberOfServersWithSealedOuterCases { get; set; }
        public int? NumberOfWorkStWithSealedOuterCases { get; set; }

    }
}
