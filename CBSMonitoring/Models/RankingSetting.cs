using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Models
{
    public class RankingSetting : Setting
    {
        #nullable disable
        [Required]
        public string Mode { get; set; }
    }
}
