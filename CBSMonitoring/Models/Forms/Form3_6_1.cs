namespace CBSMonitoring.Models.Forms
{
    public class Form3_6_1 : OrgMonitoring
    {
        public bool? IsIDPSAvailable { get; set; }
        public string? NameAndVersionOfIDPS { get; set; }
        public string? IDPSType { get; set; }
        public bool? IsLicenseForIDPSAvailable { get; set; }
    }
}
