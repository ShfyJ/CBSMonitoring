using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.DTOs
{
    public class QuestionBlockInDTO
    {
        #nullable disable
        [Required(ErrorMessage = "BlockNumber is must")]
        public string BlockNumber { get; set; }
        [Required(ErrorMessage = "BlockName is must")]
        public string BlockName { get; set; }
        [Required(ErrorMessage = "|IsActive is must")]
        public bool IsActive { get; set; }

    }
}
