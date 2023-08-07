namespace CBSMonitoring.Models
{
    public class AvailablityOfFirewalls : OrgMonitoring //3.5
    {
        public string? NameAndVersionOfFirewall {get; set;}
        public bool? IsLicenceForFireWallAvailable {get;set;}

    }
}
