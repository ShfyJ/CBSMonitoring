namespace CBSMonitoring.DTOs
{
    public class FormSectionOutDTO
    {
        #nullable disable
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string SectionNumber { get; set; }
        public int QuestionBlockId { get; set; }
        public bool IsActive { get; set; }
        public string[] ItemNames { get; set; }
    }
}
