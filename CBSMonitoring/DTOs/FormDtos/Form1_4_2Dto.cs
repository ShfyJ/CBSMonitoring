namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_4_2Dto : BaseFormDto
    {
        #nullable disable
        public bool IsComissionPresent { get; set; }
        public string ComissionDocNumber { get; set; }
        public DateTime ComissionDocDate { get; set; }
    }
}
