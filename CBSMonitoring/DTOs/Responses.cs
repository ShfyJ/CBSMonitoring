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

        public record QuestionBlockResponse(int BlockId, string BlockNumber, string BlockName, bool IsActive, int Point, int? SectionCount=null, double? Completion = null);
        public record FormSectionResponse 
        {
            #nullable disable
            public int SectionId { get; init; }
            public string SectionName { get; init; }
            public string SectionNumber { get; init; }
            public int QuestionBlockId { get; init; }
            public bool IsActive { get; init; }
            public bool IsFilled { get; set; } = false;
        }
        public record OrganizationResponse(int OrganizationId, string FullName, bool Status, string ShortName, string HeadFullName, string RegulatoryLegalAct,
            string Address, string PhoneNumber, string Email, string Fax, string EXat, int NumberOfEmployees);
    }
}
