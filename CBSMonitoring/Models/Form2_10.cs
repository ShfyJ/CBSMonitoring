namespace CBSMonitoring.Models
{
    public class Form2_10 : OrgMonitoring //2.10
    {
        public bool? IsObjectsAudited { get; set; }
        public string? AuditedObjectsNames { get; set; }
        public string? OrgNameMadeAudit { get; set; }
        public string? AuditPeriod { get; set; }
        public string? NumberOfAuditConc { get; set; }
        public DateTime? AuditConcDate { get; set; }
        public bool? IsShortcomingDetected { get; set; }
        public bool? IsShortcomingsOfObjecttEliminated { get; set; }

    }
}
