namespace CBSMonitoring.Models
{
    public class UsingVPN : OrgMonitoring //3.9
    {
        public bool? IsVPNUsed { get; set; }
        public string? PurposeAndScopeOfVPNConnections {get; set;}
    }
}
