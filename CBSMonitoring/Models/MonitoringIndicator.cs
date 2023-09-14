using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Models
{
    public class MonitoringIndicator
    {
        [Key]
        public int Id { get; set; }
        #nullable disable
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        #nullable enable
        public ICollection<QuestionBlock>? QuestionBlocks { get; set; }
    }
}
