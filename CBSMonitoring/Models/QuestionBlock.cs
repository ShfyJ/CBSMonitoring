using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Models
{
    [Index(nameof(BlockNumber), IsUnique = true)]
    public class QuestionBlock
    {
        [Key]
        public int BlockId { get; set; }
        #nullable disable
        [Required(ErrorMessage = "BlockNumber is must")]
        public string BlockNumber { get; set;}
        [Required(ErrorMessage = "BlockName is must")]
        public string BlockName { get; set;}
        [Required(ErrorMessage = "|IsActive is must")]
        public bool IsActive { get; set; }
        #nullable enable
        public ICollection<FormSection>? FormSections { get; set; }

    }
}
