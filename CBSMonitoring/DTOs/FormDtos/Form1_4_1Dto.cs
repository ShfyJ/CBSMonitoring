namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_4_1Dto : BaseFormDto
    {
        #nullable disable
        public bool IsListOfConfInfoAvailable { get; set; }
        public string ConfidentialDocNumber { get; set; }
        public DateTime ConfidentialDocDate { get; set; }

    }
}
