namespace CBSMonitoring.DTOs
{
    public class Requests
    {
        public record AuthRequest(string Email, string Password);
        public record RegistrationRequest(string Email, string UserName, string Password);
        public record ReportRequest(string SectionNumber, int Year = 0, int Quarter = 0);
        public record FormItemRequest(string ItemLabel, string ItemName, bool IsMain, bool IsActive, int ItemTypeId,
            int FormSectionId, int Order, bool IsRequired = true, string[]? SelectOptions = null, 
            bool IsListItem = false, int? ListIndex = null, string? ListLabel = null);
        public record FormItemTypeRequest(string TypeName, string TypeDescription, bool IsActive);
        public record TimelyExecutionOfPlanRequest(string SectNameWithNumber, string Doers, DateTime DeadlineOfPlan, 
            string Status, DateTime CompletionDate, string? Comments = null);

        public record QualificationImprovedEmployeeRequest(string FullName, string Position, string CourseName,
            string EducationPeriod, string CourseConductedOrgName);
    }
}
