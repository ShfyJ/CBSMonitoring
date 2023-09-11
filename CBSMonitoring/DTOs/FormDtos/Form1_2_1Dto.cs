namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_2_1Dto
    {
        #nullable disable
        public string OrganizationName { get; set; }
        public int QuarterIndex { get; set; }
        public int Year { get; set; }
        public string SectionNumber { get; set; }
        public bool AreInternalRegulationsAvailable { get; set; }
        public int NumberOfRegDocs { get; set; }
        public string ListOfRegDocs { get; set; }
    }
}
