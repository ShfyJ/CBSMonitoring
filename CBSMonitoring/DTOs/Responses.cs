namespace CBSMonitoring.DTOs
{
    public class Responses
    {
        public record FormItemResponse(int FormItemId, string ItemLabel, string ItemName, bool IsMain, bool IsActive, int ItemTypeId,
            int FormSectionId, int Order, string[]? SelectOptions = null, bool IsListItem = false, int? ListIndex = null);
    }
}
