namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_3Dto : BaseFormDto
    {
        #nullable disable
        public bool AgreedWithAuthBody { get; set; }
        public string FileDescription { get; set; } = "Файл";
        #nullable enable
        public int? FileId { get; set; }
    }
}
