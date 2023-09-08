using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CBSMonitoring.Models.Forms;

namespace CBSMonitoring.Models
{
    public class QualificationImprovedEmployee
    {
        [Key]
        public int Id { get; set; }
#nullable disable
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string EducationPeriod { get; set; }
        [Required]
        public string CourseConductedOrgName { get; set; }
        public int OrgMonitoringId { get; set; }
        [ForeignKey(nameof(OrgMonitoringId))]
        public Form2_8_1 OrgMonitoring { get; set; }

        public int CertificateFileId { get; set; }
        [ForeignKey(nameof(CertificateFileId))]
        public FileModel Certificate { get; set; }
    }
}
