namespace CBSMonitoring.Models.Forms
{
    public class Form2_11_6 : OrgMonitoring
    {
        public bool? IsServerRoomOrDataCenterAvailable { get; set; }
        public int? NumberOfServerRoom { get; set; }
        public int? NumberOfDataCentre { get; set; }
        public int? NumberOfSRandDCWithMetalDoor { get; set; }
        public int? NumberOfSRandDCWithWithSystemControl { get; set; }
        public bool? IsCoolingSystemAvailable { get; set; }
        public bool? IsAntiFireEquipAvailable { get; set; }
        public bool? IsPlanForPreventiveMaintAvailable { get; set; }
        public bool? IsVideoCamAvailable { get; set; }
        public bool? IsFalseFloorAndCeilingAvailable { get; set; }
        public bool? IsTempSensorsAvailable { get; set; }
        public bool? IsLogsForSRAndDCEntrance { get; set; }
    }
}
