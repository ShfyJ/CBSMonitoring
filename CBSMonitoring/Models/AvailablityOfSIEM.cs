namespace CBSMonitoring.Models
{
    public class AvailablityOfSIEM : OrgMonitoring //3.11
    {
        public string? NameAndVersionOfSIEM { get; set; }
        public bool? IsLicenseForSIEMAvailable { get; set; }
    }
}
