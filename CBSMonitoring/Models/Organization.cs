using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Model
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        public bool Status { get; set; } = true;
        #nullable disable
        [Required]
        public string FullName { get; set; }
        public string ShortName { get; set; } = string.Empty;
        public string HeadFullName { get; set; } = string.Empty;     //fulname
        public string RegulatoryLegalAct { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string EXat { get; set; } = string.Empty;
        public int NumberOfEmployees { get; set; } = 0;


    }
}
