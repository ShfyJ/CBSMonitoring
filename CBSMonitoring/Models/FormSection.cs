using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    [Index(nameof(SectionNumber), IsUnique = true)]
    public class FormSection
    {
        [Key]
        public int SectionId { get; set; }
        [Required(ErrorMessage = "IsActive is must")]
        public bool IsActive { get; set; }
        #nullable disable
        [Required(ErrorMessage = "SectionName is must")]
        public string SectionName { get; set; }
        [Required(ErrorMessage = "SectionNumber is must")]
        public string SectionNumber { get; set; }
        public int QuestionBlockId { get; set; }
        [ForeignKey(nameof(QuestionBlockId))]
        public QuestionBlock QuestionBlock { get; set; }
        #nullable enable
        public ICollection<FormItem>? FormItems { get; set; }

    }
}
