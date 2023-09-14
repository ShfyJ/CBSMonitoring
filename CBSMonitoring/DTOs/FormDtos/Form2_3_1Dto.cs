namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_3_1Dto : BaseFormDto
    {
        #nullable disable
        public bool IsListOfProtectedObjAvailable { get; set; }
        public string FileDescription { get; set; } = "Файл";
        public int FileId { get; set; }
    }
}
