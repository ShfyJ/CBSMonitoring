using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Models
{
    public class Setting
    {
        [Key] 
        public int Id { get; set; }
        #nullable disable
        [Required]
        public string SettingName { get; set; }
        public bool IsEnabled { get; set; }
    }
}
