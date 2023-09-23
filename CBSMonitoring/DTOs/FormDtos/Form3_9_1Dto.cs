using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_9_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsVPNUsed { get; init; }
        [PropertyOrder(2)]
        public string? PurposeAndScopeOfVPNConnections { get; init; }
    }
}
