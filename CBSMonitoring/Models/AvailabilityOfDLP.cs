namespace CBSMonitoring.Models
{
    public class AvailabilityOfDLP : OrgMonitoring //3.10
    {
        public string? NameAndVersionOfDLP { get; set; }
        public bool? IsLicenceOfDLPAvaliable { get; set; }
        public int? NumberOfWorkRoomsWithDLP { get; set; }
    }
}
