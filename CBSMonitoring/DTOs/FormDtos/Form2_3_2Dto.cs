namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_3_2Dto : BaseFormDto
    {
        #nullable disable
        public bool IsObjectsClassified { get; init; }
        public string FileDescription { get; init; } = "Файл";
        public int FileId { get; init; }
    }
}
