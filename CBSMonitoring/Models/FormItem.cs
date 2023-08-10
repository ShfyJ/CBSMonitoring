using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class FormItem
    {
        [Key]
        public int ItemId { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public int? ListIndex { get; set; }             //If the form has list
        public int? LinkedItemId { get; set; }
        public string[]? SelectOptions { get; set; }
        #nullable disable
        public string ItemLabel { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }            //DateTime, file, select, int, float, text      
        public int FormId { get; set; }
        [ForeignKey(nameof(FormId))]
        public MonitoringForm MonitoringForm { get; set; }
    }
}
