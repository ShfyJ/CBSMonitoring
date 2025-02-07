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
        [Range(1, 4, ErrorMessage = "Неверный номер квартала")]
        public int QuarterIndex { get; set; }
        [Range(2000, 2100, ErrorMessage = "Год вне диапазона (2000-2100)")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Требуется номер раздела")]
        public string SectionNumber { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsSent { get; set; } = false;

    }
}
