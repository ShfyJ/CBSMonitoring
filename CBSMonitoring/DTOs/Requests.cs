using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.DTOs
{
    public class Requests
    {
        public record LoginRequest(string UserName, string Password);
        public class RegistrationRequest 
        {
            #nullable disable
            [Required(ErrorMessage = "User Name is required")]
            public string UserName { get; init; }
            [Required(ErrorMessage = "Email is required")]
            public string Email { get; init; }
            [Required(ErrorMessage = "Full Name is required")]
            public string FullName { get; init; }
            [Required(ErrorMessage = "Organization is required")]
            public int OrganizationId { get; init; }
            [Required(ErrorMessage = "Password is required")]
            public string Password { get; init; }
            [Required(ErrorMessage = "Role is required")]
            public List<string> Roles { get; init; }
            #nullable enable
            public string? Position { get; init; } = null;
            public string? PhoneNumber { get; init; } = null;
            
        }

        public class UserSelfUpdateRequest
        {
            #nullable disable
            [Required(ErrorMessage = "Full name is required")]
            public string FullName { get; init; }
            #nullable enable
            public string? PhoneNumber { get; init; } = null;
            public string? Position { get; init; } = null;
        }
        public class UserUpdateRequest : UserSelfUpdateRequest
        {
            #nullable disable
            [Required(ErrorMessage = "UserName is required")]
            public string UserName { get; init; }

            [Required(ErrorMessage = "Organization is required")]
            public int OrganizationId { get; init; }

            #nullable enable
            public List<string>? Roles { get; init; }
            #nullable disable
        }

        public record UpdatePasswordRequest(string OldPassword, string NewPassword);
        public record ReportRequest
        {
            #nullable disable
            [Required]
            public string SectionNumber { get; init; } 
            public int OrganizationId { get; set; }
            public Period Period { get; init; }

            public ReportRequest(string sectionNumber, int organizationId, int year, int quarter)
            {
                SectionNumber = sectionNumber;
                OrganizationId = organizationId;
                Period = new Period(year, quarter);
            }
        }
        public record ReportRequestByQb
        {
            [Required]
            public int QbId { get; init; }
            public int OrganizationId { get; set; } = 0;
            public Period Period { get; init; }
        }
        public record FormItemRequest(string ItemLabel, string LabelInDisplay, string ItemName, bool IsMain, bool IsActive, int ItemTypeId,
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
            public int OrganizationId { get; set; }
            public Period Period { get; init; }
        }
        
        public record QuestionBlockRequest(string BlockNumber, string BlockName, bool IsActive, int Point);
        public record FormSectionRequest(string SectionName, string SectionNumber, int QuestionBlockId, bool IsActive);
        public record OrganizationRequest(string FullName, bool Status=true, string ShortName=null, string HeadFullName=null, string RegulatoryLegalAct=null,
            string Address=null, string PhoneNumber=null, string Email=null, string Fax=null, string EXat=null, int NumberOfEmployees=0);
        
        public record EvaluationRequest(string BlockNumber, double Score, Period Period, int OrganizationId, string Comment = null);        
        public class ScoreRequest
        {
            public Period Period { get; init; }
            public int OrganizationId { get; set; }
        }
        public class ScoreRequestByIndicator : ScoreRequest
        {
            public string BlockNumber { get; init; }
        }

        public record ReEvaluationRequest(int EvaluationId, double Score, string Comment);
    }
}
