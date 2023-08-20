using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.DTOs
{
    public class FormItemDTO
    {
        public int? ItemId { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int Order { get; set; }
        public int? ListIndex { get; set; } = null;                 //If the form has list, the index order in the list
        public int? LinkedItemId { get; set; } = null;
        public string[]? SelectOptions { get; set; } = null;
        #nullable disable
        [Required]
        public string ItemLabel { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemType { get; set; }            //DateTime, file, select, int, float, text      
        [Required]
        public int FormId { get; set; }
    }
}
