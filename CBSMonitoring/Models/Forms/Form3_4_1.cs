namespace CBSMonitoring.Models.Forms
{
    public class Form3_4_1 : OrgMonitoring  //3.4
    {
        public bool? IsAnitivirusAvailable { get; set; }
        public string? NameAndVersionOfAntivirus { get; set; }
        public bool? IsLicenseForAntivirusAvailable { get; set; }
        public int? NumberOfServersWithAntivirus { get; set; }
        public int? NumberOfWRsWithAntivirus { get; set; }
    }
}
