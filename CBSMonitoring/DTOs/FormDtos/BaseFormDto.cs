using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class BaseFormDto
    {
        #nullable disable
        [PropertyOrder(0)]
        [PropertyDisplay(false)]
        public int MonitoringId { get; init; }
        [PropertyOrder(0)]
        [PropertyDisplay(false)]
        public string OrganizationName { get; init; }
        [PropertyOrder(0)]
        [PropertyDisplay(false)]
        public int QuarterIndex { get; init; }
        [PropertyOrder(0)]
        [PropertyDisplay(false)]
        public int Year { get; init; }
        [PropertyOrder(0)]
        [PropertyDisplay(false)]
        public string SectionNumber { get; init; }
    }
}
