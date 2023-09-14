namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_2Dto : BaseFormDto
    {
        #nullable disable
        public bool IsReviewedByCBS { get; init; }
        public string FileDescription { get; init; } = "Файл";
        #nullable enable
        public int? FileId { get; init; }
    }
}
