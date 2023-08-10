namespace CBSMonitoring.Models
{
    public class Form3_2 : OrgMonitoring //3.2
    {
        public bool? IsAccessControlToNetworkInCentreAvailable { get; set; }
        public string? NameOfToolForAccessControlInCentre { get; set; } 
        public bool? IsAccessControlToNetworkInStrucDivAvailable { get; set; }
        public int? NumberOfOrgsWithAccesControlToNetwork {get;set; }
        public string? NameOfToolsForAccessControl { get; set; }
    }
}
