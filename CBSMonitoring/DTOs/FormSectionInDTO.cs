using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CBSMonitoring.DTOs
{
    public class FormSectionInDTO
    {
        #nullable disable
        public string SectionName { get; set; }
        public string SectionNumber { get; set; }
        public int QuestionBlockId { get; set; }
        public bool IsActive { get; set; }

    }
}
