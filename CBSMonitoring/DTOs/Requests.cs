using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.DTOs
{
    public class Requests
    {
        public record LoginRequest(string UserName, string Password);
        public class RegistrationRequest 
        {
            #nullable disable
            [Required(ErrorMessage = "Это поле обязательно")]
            public string UserName { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string Email { get; init; }
            [MaxLength(50, ErrorMessage = "Длина полного имени должна быть менее 50 букв")]
            [Required(ErrorMessage = "Это поле обязательно")]
            public string FullName { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            [Range(1, 100, ErrorMessage = "Неправильный идентификатор организации")]
            public int OrganizationId { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string Password { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public List<string> Roles { get; init; }
            #nullable enable
            [Required(ErrorMessage = "Это поле обязательно")]
            public string? Position { get; init; }
            public string? PhoneNumber { get; init; } = null;
            
        }

        public class UserSelfUpdateRequest
        {
            #nullable disable
            [Required(ErrorMessage = "Это поле обязательно")]
            public string FullName { get; init; }
            #nullable enable
            public string? PhoneNumber { get; init; } = null;
            public string? Position { get; init; } = null;
        }
        public class UserUpdateRequest : UserSelfUpdateRequest
        {
            #nullable disable
            [Required(ErrorMessage = "Это поле обязательно")]
            public string UserName { get; init; }

            [Required(ErrorMessage = "Это поле обязательно")]
            public int OrganizationId { get; init; }

            #nullable enable
            public List<string>? Roles { get; init; }
            #nullable disable
        }

        public class UpdatePasswordRequest 
        {
            [Required(ErrorMessage = "Это поле обязательно")]
            public string OldPassword { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string NewPassword { get; init; }
        }
        public record ReportRequest
        {
            #nullable disable
            [Required]
            public string SectionNumber { get; init; }
            public int OrganizationId { get; set; }
            public Period Period { get; init; }
            public bool IsSent { get; set; }

            public ReportRequest(string sectionNumber, int organizationId, int year, int quarter, bool isSent)
            {
                SectionNumber = sectionNumber;
                OrganizationId = organizationId;
                Period = new Period(year, quarter);
                IsSent = isSent;
            }
        }
        public record ReportRequestByQb
        {
            [Required]
            public int QbId { get; init; }
            public int OrganizationId { get; set; } = 0;
            public Period Period { get; init; }
            public ReportRequestByQb()
            {
                Period = new Period();
            }
        }
        public class FormItemRequest
        {
            [Required(ErrorMessage = "Это поле обязательно")]
            public string ItemLabel { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string LabelInDisplay { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string ItemName { get; init; }
            public bool IsMain { get; init; } = false;
            [Required(ErrorMessage = "Это поле обязательно")]
            public int ItemTypeId { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public int FormSectionId { get; init; }
            public int Order { get; init; }
            public bool IsRequired { get; init; } = true;
            public string[] SelectOptions { get; init; } = null;
            public bool IsListItem { get; init; } = false;
            public int? ListIndex { get; init; } = null;
            public string ListLabel { get; init; } = null;

        }
        public class FormItemTypeRequest 
        {
            [Required(ErrorMessage = "Это поле обязательно")]
            public string TypeName { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string TypeDescription { get; init; }
            public bool IsActive { get; init; } = true;
        }
        public class TimelyExecutionOfPlanRequest 
        {
            [Required(ErrorMessage = "Это поле обязательно")]
            public string SectNameWithNumber { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string Doers { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            [DataType(DataType.Date, ErrorMessage = "Введена неверная дата")]
            public DateTime DeadlineOfPlan { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string Status { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            [DataType(DataType.Date, ErrorMessage = "Введена неверная дата")]
            public DateTime CompletionDate { get; init; }
            public string Comments { get; init; } = null;
        } 

        public class QualificationImprovedEmployeeRequest 
        {
            [Required(ErrorMessage = "Это поле обязательно")]
            public string FullName { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string Position { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string CourseName { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string EducationPeriod { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string CourseConductedOrgName { get; init; }
        }
        public record LevelRequest
        {
            [Required]
            public int OrganizationId { get; set; }
            public Period Period { get; init; }
        }
        
        public record QuestionBlockRequest(string BlockNumber, string BlockName, bool IsActive, int Point);
        public record FormSectionRequest(string SectionName, /*string SectionNumber, int QuestionBlockId, */ bool IsActive);
        public class OrganizationRequest
        {
            [Required(ErrorMessage = "Это поле обязательно")]
            public string FullName { get; init; }
            public bool Status { get; init; } = true;
            [Required(ErrorMessage = "Это поле обязательно")]
            public string ShortName { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string HeadFullName { get; init; }
            public string RegulatoryLegalAct { get; init; } = null;
            [Required(ErrorMessage = "Это поле обязательно")]
            public string Address { get; init; }
            public string PhoneNumber { get; init; } = null;
            public string Email { get; init; } = null;
            public string Fax { get; init; } = null;
            public string EXat { get; init; } = null;
            public int NumberOfEmployees { get; init; } = 0;
        }

        public class EvaluationRequest 
        {
            [Required(ErrorMessage = "Это поле обязательно")]
            public string BlockNumber { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            [Range(0.0, Double.MaxValue, ErrorMessage = "Оценка должна быть больше {1}.")]
            public double Score { get; init; }
            public Period Period { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public int OrganizationId { get; init; }
            public string Comment { get; init; } = null;
        }     
        public class ScoreRequest
        {
            public Period Period { get; init; }
            public int OrganizationId { get; set; } = 0;
        }
        public class ScoreRequestByIndicator : ScoreRequest
        {
            public string BlockNumber { get; init; }
        }

        public class ReEvaluationRequest 
        {
            [Required(ErrorMessage = "Это поле обязательно")]
            public int EvaluationId { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            [Range(0.0, Double.MaxValue, ErrorMessage = "Оценка должна быть больше {1}.")]
            public double Score { get; init; }
            [Required(ErrorMessage = "Это поле обязательно")]
            public string Comment { get; init;}
        }

        public record MessageRequest(string SenderId,string Header, string Content, List<string> ReceiverIds=null);
        public record DeleteMsgRequest(int MessageId, string UserId, bool IsSender);
        public record CatalogFile(string Description, IFormFile File);
        public record MessageReadRequest (int MessageId, string UserId);
        public record OtpVerificationRequest(string Username, string OTP, string TempToken);
        public record SendOtpRequest(string Username, string TempToken);
    }
}
