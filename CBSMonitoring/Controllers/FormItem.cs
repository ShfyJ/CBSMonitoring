using CBSMonitoring.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Controllers
{
    public class FormItem
    {
        [Key]
        public int ItemId { get; set; }
        public int? LinkedItemId { get; set; }
        #nullable disable
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public int FormId { get; set; }
        [ForeignKey(nameof(FormId))]
        public MonitoringForm MonitoringForm { get; set; }
    }
}
