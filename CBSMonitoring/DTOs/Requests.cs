using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.DTOs
{
    public class Requests
    {
        
        public record AuthRequest(string Email, string Password);
        public record RegistrationRequest(string Email, string UserName, string Password);
        public record ReportRequest
        {
            #nullable disable
            [Required]
            public string SectionNumber { get; init; }
            public int OrganizationId { get; set; }
            public int Year { get; init; } = DateTime.Now.Year;
            public int Quarter { get; init; } = (DateTime.Now.Month - 1) / 3 + 1;
        }
        public record FormItemRequest(string ItemLabel, string ItemName, bool IsMain, bool IsActive, int ItemTypeId,
            int FormSectionId, int Order, bool IsRequired = true, string[] SelectOptions = null, 
            bool IsListItem = false, int? ListIndex = null, string ListLabel = null);
        public record FormItemTypeRequest(string TypeName, string TypeDescription, bool IsActive);
        public record TimelyExecutionOfPlanRequest(string SectNameWithNumber, string Doers, DateTime DeadlineOfPlan, 
            string Status, DateTime CompletionDate, string Comments = null);

        public record QualificationImprovedEmployeeRequest(string FullName, string Position, string CourseName,
            string EducationPeriod, string CourseConductedOrgName);
        public record LevelRequest
        {
            [Required]
            public int OrganizationId { get; init; }
            public int Year { get; init; } = DateTime.Now.Year;
            public int Quarter { get; init; } = (DateTime.Now.Month - 1) / 3 + 1;
        }

        public record QuestionBlockRequest(string BlockNumber, string BlockName, bool IsActive, int Point);
        public record FormSectionRequest(string SectionName, string SectionNumber, int QuestionBlockId, bool IsActive);
        public record OrganizationRequest(string FullName, bool Status=true, string ShortName=null, string HeadFullName=null, string RegulatoryLegalAct=null,
            string Address=null, string PhoneNumber=null, string Email=null, string Fax=null, string EXat=null, int NumberOfEmployees=0);
    }
}
