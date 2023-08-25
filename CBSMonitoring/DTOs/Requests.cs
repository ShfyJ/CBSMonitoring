namespace CBSMonitoring.DTOs
{
    public class Requests
    {
        public record ReportRequest(string sectionNumber, int year = 0, int quater = 0);
        public record FormItemRequest(string ItemLabel, string ItemName, bool IsMain, bool IsActive,  int ItemTypeId, 
            int FormSectionId, int Order, string[]? SelectOptions = null, bool IsListItem = false, int? ListIndex = null, string? ListLabel = null);
        public record FormItemTypeRequest(string TypeName, string TypeDescription, bool IsActive);
    }
}
