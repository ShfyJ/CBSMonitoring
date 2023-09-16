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
        public bool IsListItem { get; set; } = false;
        public int? ListIndex { get; set; }
        public string? ListLabel { get; set; }
        #nullable disable
        public bool IsRequired { get; set; } = true;
        public string ItemLabel { get; set; }
        public string LabelInDisplay { get; set; }
        public string ItemName { get; set; }
        public int ItemTypeId { get; set; }
        [ForeignKey(nameof(ItemTypeId))]
        public FormItemType FormItemType { get; set; }
        public int FormSectionId { get; set; }
        [ForeignKey(nameof(FormSectionId))]
        public FormSection FormSection { get; set; }
    }
}
