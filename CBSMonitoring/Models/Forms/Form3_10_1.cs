namespace CBSMonitoring.Models.Forms
{
    public class Form3_10_1 : OrgMonitoring //3.10
    {
        public bool? IsDLPAvailable { get; set; }
        public string? NameAndVersionOfDLP { get; set; }
        public bool? IsLicenceOfDLPAvaliable { get; set; }
        public int? NumberOfWorkRoomsWithDLP { get; set; }
    }
}
