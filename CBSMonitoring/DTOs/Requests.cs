namespace CBSMonitoring.DTOs
{
    public class Requests
    {
        public record ReportRequest(string sectionNumber, int year = 0, int quater = 0);
    }
}
