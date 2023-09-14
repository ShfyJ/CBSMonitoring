namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_1Dto : BaseFormDto
    {
        #nullable disable
        public bool HasPolicy { get; init; }
        public string FileDescription { get; init; } = "Файл";
        #nullable enable
        public int? FileId { get; init; }

    }

}
