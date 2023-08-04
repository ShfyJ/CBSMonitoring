namespace CBSMonitoring.Models
{
    public class PeriodicUpdatesOfSystem : OrgMonitoring //2.14
    {
        public int? NumOfServersWithLicensedOS { get; set; }
        public int? NumOfServersWithUpdatingOs { get; set; }
        public int? NumOfWRoomswihLicensedOS { get; set; }
    }
}
