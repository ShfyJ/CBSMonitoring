using CBSMonitoring.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class OrgMonitoring
    {
        [Key]
        public int MonitoringId { get; set; }
        #nullable disable
        public int OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }
        public int QuaterIndex { get; set; }
        public int Year { get; set; }
        public string SectionNumber { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
