namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_2_1Dto : BaseFormDto
    {
        #nullable disable
        public bool AreInternalRegulationsAvailable { get; set; }
        public int NumberOfRegDocs { get; set; }
        public string ListOfRegDocs { get; set; }
    }
}
