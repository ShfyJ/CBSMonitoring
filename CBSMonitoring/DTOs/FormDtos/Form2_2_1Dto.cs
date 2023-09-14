namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_2_1Dto : BaseFormDto
    {
        #nullable disable
        public int NumberOfSectsInActionPlan { get; set; }
        public int NumberOfDoneSects { get; set; }
        public int NumberOfDoneSectsInTime { get; set; }
        public string FileDescription { get; set; } = "Файл";
        public int FileId { get; set; }
    }
}
