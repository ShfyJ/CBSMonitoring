using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class FormItem
    {
        [Key]
        public int ItemId { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Это поле обязательно")]
        public bool IsMain { get; set; }
        public int Order { get; set; } = 0;
        public string[]? SelectOptions { get; set; } = null;
        public bool IsListItem { get; set; } = false;
        public int? ListIndex { get; set; }
        public string? ListLabel { get; set; }
        public string? ListName { get; set; }
        #nullable disable
        public bool IsRequired { get; set; } = true;
        [Required(ErrorMessage = "Это поле обязательно")]
        public string ItemLabel { get; set; }
       // [Required(ErrorMessage = "Это поле обязательно")]
        public string LabelInDisplay { get; set; } = string.Empty;
        [Required(ErrorMessage = "Это поле обязательно")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно")]
        public int ItemTypeId { get; set; }
        [ForeignKey(nameof(ItemTypeId))]
        public FormItemType FormItemType { get; set; }
        public int FormSectionId { get; set; }
        [ForeignKey(nameof(FormSectionId))]
        public FormSection FormSection { get; set; }
    }
}
