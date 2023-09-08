namespace CBSMonitoring.DTOs
{
    public class OrgMonitoringDto
    {
        public string OrganizationName { get;}
        public int Year { get;}
        public int QuarterIndex { get; }
        public string SectionNumber { get; }

        public OrgMonitoringDto(string organizationName, int year, int quarterIndex, string sectionNumber)
        {
            OrganizationName = organizationName;
            Year = year;
            QuarterIndex = quarterIndex;
            SectionNumber = sectionNumber;
        }
    }
}
