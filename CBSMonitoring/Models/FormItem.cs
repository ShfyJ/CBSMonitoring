using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class FormItem
    {
        [Key]
        public int ItemId { get; set; }
        public bool IsActive { get; set; }
        public bool IsMain { get; set; }
        public int Order { get; set; } = 0;
        public string[]? SelectOptions { get; set; } = null;
        #nullable disable
        public string ItemLabel { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }            //DateTime, file, select, int, float, text, bool      
        public int FormSectionId { get; set; }
        [ForeignKey(nameof(FormSectionId))]
        public FormSection FormSection { get; set; }
    }
}
