﻿namespace CBSMonitoring.DTOs
{
    public class Responses
    {
        public record FormItemResponse(int ItemId, string ItemLabel, string ItemName, bool IsMain, bool IsActive, bool IsRequired, string ItemTypeName,
            int FormSectionId, int Order, string[]? SelectOptions = null, bool IsListItem = false, int? ListIndex = null);

        public record TimelyExecutionOfPlanResponse(int Id, string SectNameWithNumber, string Doers, DateTime DeadlineOfPlan, string Status, DateTime CompletionDate, int OrgMonitoringId, string? Comments = null);
    }
}
