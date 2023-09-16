using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_5_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsFirewallAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NameAndVersionOfFirewall { get; init; }
        [PropertyOrder(3)]
        public string? FirewallType { get; init; }
        [PropertyOrder(4)]
        public bool? IsLicenceForFireWallAvailable { get; init; }
    }
}
