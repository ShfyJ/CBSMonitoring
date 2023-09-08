namespace CBSMonitoring.DTOs
{
    public class Responses
    {
        public record AuthResponse(string UserName, string Email, string Token);
        public record RegistrationResponse(string UserName, string Email, string Password);
        public record FormItemResponse(int ItemId, string ItemLabel, string ItemName, bool IsMain, bool IsActive, bool IsRequired, string ItemTypeName,
            int FormSectionId, int Order, string[]? SelectOptions = null, bool IsListItem = false, int? ListIndex = null);

        public record TimelyExecutionOfPlanResponse(int Id, string SectNameWithNumber, string Doers, DateTime DeadlineOfPlan, string Status, DateTime CompletionDate, int OrgMonitoringId, string? Comments = null);
        public record QualificationImprovedEmployeeResponse(int Id, string FullName, string Position, string CourseName,
            string EducationPeriod, string CourseConductedOrgName, int OrgMonitoringId, int CertificateFileId);
    }
}
