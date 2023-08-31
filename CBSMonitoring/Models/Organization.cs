using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Model
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
#nullable disable
        [Required]
        public string OrganizationName { get; set; }
        public bool Status { get; set; } = true;

    }
}
