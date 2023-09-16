using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_10_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsObjectsAudited { get; init; }
        [PropertyOrder(2)]
        public string? AuditedObjectsNames { get; init; }
        [PropertyOrder(3)]
        public string? OrgNameMadeAudit { get; init; }
        [PropertyOrder(4)]
        public string? AuditPeriod { get; init; }
        [PropertyOrder(5)]
        public string? NumberOfAuditConc { get; init; }
        [PropertyOrder(6)]
        public DateTime? AuditConcDate { get; init; }
        [PropertyOrder(7)]
        public bool? IsShortcomingDetected { get; init; }
        [PropertyOrder(8)]
        public bool? IsShortcomingsOfObjecttEliminated { get; init; }
    }
}
