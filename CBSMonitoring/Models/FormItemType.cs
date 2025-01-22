using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Models
{
    public class FormItemType
    {
        [Key]
        public int TypeId { get; set; }
        #nullable disable
        [Required(ErrorMessage = "Это поле обязательно")]
        public string TypeName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно")]
        public string TypeDescription { get; set; }
        public bool IsActive { get; set; }
        public ICollection<FormItem> FormItems { get; set; }
    }
}
