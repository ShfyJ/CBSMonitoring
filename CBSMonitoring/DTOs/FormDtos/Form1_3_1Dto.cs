namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_3_1Dto : BaseFormDto
    {
        #nullable disable
        public bool AreRegsAndRecordsAvailable { get; set; }
        public int NumberOfRegAndRecords { get; set; }
        public string ListOfRegAndRecords { get; set; }
    }
}
