namespace CBSMonitoring.Models.Forms
{
    public class Form2_14_1 : OrgMonitoring //2.14
    {
        public bool? IsSystemUpdateHold { get; set; }
        public int? NumOfServersWithLicensedOS { get; set; }
        public int? NumOfServersWithUpdatingOs { get; set; }
        public int? NumOfWRoomswihLicensedOS { get; set; }
    }
}
