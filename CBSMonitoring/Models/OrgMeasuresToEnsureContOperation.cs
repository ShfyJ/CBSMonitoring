namespace CBSMonitoring.Models
{
    public class OrgMeasuresToEnsureContOperation : OrgMonitoring //2.17
    {
        public bool? AvailabilityOfFireAlarmSystInRoomWithSEq { get; set; }
        public bool? PresenceOfGasFireExtSystInRoomWithSEq { get; set; }
        public bool? AvailablityOfUPSForSEq { get; set; }
        public int? NumberOfServersWithUPS { get; set; }
        public bool? IsUPSAvailableForWRooms { get; set; }
        public int? WorkRoomsWithUPS { get; set; }
        public bool? AvailablityOfAlternativePowerL { get; set; }
        public bool? AvailablityOfGenerators { get; set; }
        public int? NumberOfGenerators { get; set; }
    }
}
