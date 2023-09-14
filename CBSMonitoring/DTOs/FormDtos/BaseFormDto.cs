namespace CBSMonitoring.DTOs.FormDtos
{
    public class BaseFormDto
    {
        #nullable disable
        public int MonitoringId { get; init; }
        public string OrganizationName { get; init; }
        public int QuarterIndex { get; init; }
        public int Year { get; init; }
        public string SectionNumber { get; init; }
    }
}
