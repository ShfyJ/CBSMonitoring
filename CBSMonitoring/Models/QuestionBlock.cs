using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    [Index(nameof(BlockNumber), IsUnique = true)]
    public class QuestionBlock
    {
        [Key]
        public int BlockId { get; set; }
        #nullable disable
        [Required(ErrorMessage = "BlockNumber is must")]
        public string BlockNumber { get; set; }
        [Required(ErrorMessage = "BlockName is must")]
        public string BlockName { get; set; }
        [Required(ErrorMessage = "IsActive is must")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Point is must")]
        public int MaxScore { get; set; } = 0;
        public int IdicatorId { get; set; }
        [ForeignKey(nameof(IdicatorId))]
        public MonitoringIndicator MonitoringIndicator { get; set; }
        public ICollection<FormSection> FormSections { get; set; }

    }
}
