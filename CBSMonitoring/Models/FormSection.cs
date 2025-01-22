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
        [Required(ErrorMessage = "Это поле обязательно")]
        public bool IsActive { get; set; }
        #nullable disable
        [Required(ErrorMessage = "Это поле обязательно")]
        public string SectionName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно")]
        public string SectionNumber { get; set; }
        public int QuestionBlockId { get; set; }
        [ForeignKey(nameof(QuestionBlockId))]
        public QuestionBlock QuestionBlock { get; set; }
        #nullable enable
        public ICollection<FormItem>? FormItems { get; set; }

    }
}
