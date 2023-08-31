using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class TimelyExecutionOfPlan
    {
        [Key]
        public int Id { get; set; }

        #nullable disable
        public string SectNameWithNumber { get; set; }
        public string Doers { get; set; }
        public DateTime DeadlineOfPlan { get; set; }
        public string Status { get; set; }
        public DateTime CompletionDate { get; set; }
        public int OrgMonitoringId { get; set; }
        [ForeignKey(nameof(OrgMonitoringId))]
        public OrgMonitoring OrgMonitoring { get; set; }
        #nullable enable
        public string? Comments { get; set; }
    }
}
