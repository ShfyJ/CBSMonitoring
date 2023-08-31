namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_1Dto
    {
        #nullable disable
        public string OrganizationName { get; set; }
        public int QuarterIndex { get; set; }
        public int Year { get; set; }
        public string SectionNumber { get; set; }
        public bool HasPolicy { get; set; }
        public string FileDescription { get; set; }
        #nullable enable
        public int? FileId { get; set; }

    }

}
