using CBSMonitoring.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string? FullName { get; set; }
        [Required]
        public int OrganizationId { get; set; }

        #nullable disable
        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }

        [Required]
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsFirstLogin { get; set; } = true;
    }
}
