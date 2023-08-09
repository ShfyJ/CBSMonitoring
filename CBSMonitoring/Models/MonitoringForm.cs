using CBSMonitoring.Controllers;
using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Models
{
    public class MonitoringForm
    {
        [Key]
        public int FormId { get; set; }
        #nullable disable
        [Required]
        public string FormNumber { get; set;}
        public bool IsActive { get; set; }
        public ICollection<FormItem> FormItems { get; set; }

    }
}
