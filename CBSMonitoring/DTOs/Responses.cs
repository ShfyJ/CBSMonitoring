using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs
{
    public class Responses
    {
        public record User(string? UserName, string? Email, string? FullName, string OrganizationName, string Position, string? PhoneNumber);
        public record UpdatePasswordResponse(Enum Flag, string Message);
        public class ReportResponse 
        {
            #nullable disable
            public string PropertyLabel { get; init; }
            #nullable enable
            public object? Value { get; init; } = null;
            public int Order { get; init; } = 0;
            public string Type { get; init; } = string.Empty;
            public bool IsCollection { get; init; } = false;
            public List<List<ReportResponse>>? CollectionItems { get; init; } = null;
            public bool IsFileWithInfo { get; init; } = false;
            public FileInfo? FileInformation { get; init; } = null;
            public bool ToBeDisplayed { get; init; }

            public ReportResponse(string propertyLabel, object value, bool toBeDisplayed)
            {
                PropertyLabel = propertyLabel;
                Value = value;
                ToBeDisplayed = toBeDisplayed;
            }

            public record FileInfo(string? DocNumber, DateTime? DocDate);

            public ReportResponse() { }
        }
        public record LoginResponse(string Token, string UserName, IList<string> UserRoles);
        public record AuthResponse(string UserName, string Email, string Token);
        public record RegistrationResponse(string UserName, string Email, string Password);
        public record FormItemResponse(int ItemId, string ItemLabel, string LabelInDisplay, string ItemName, bool IsMain, bool IsActive, bool IsRequired, string ItemTypeName,
            int FormSectionId, int Order, string[]? SelectOptions = null, string? ListLabel = null, string? ListName = null, bool IsListItem = false, int? ListIndex = null);

        public record TimelyExecutionOfPlanResponse 
        {
            [PropertyOrder(0)]
            [PropertyDisplay(false)]
            public int Id { get; init; }

            #nullable disable
            [PropertyOrder(1)]
            [PropertyDisplay(true)]
            public string SectNameWithNumber { get; init; }

            [PropertyOrder(2)]
            [PropertyDisplay(true)]
            public string Doers { get; init; }

            [PropertyOrder(3)]
            [PropertyDisplay(true)]
            public DateTime DeadlineOfPlan { get; init; }

            [PropertyOrder(4)]
            [PropertyDisplay(true)]
            public string Status { get; init; }

            [PropertyOrder(5)]
            [PropertyDisplay(true)]
            public DateTime CompletionDate { get; init; }

            [PropertyOrder(0)]
            [PropertyDisplay(false)]
            public int OrgMonitoringId { get; init; }

            #nullable enable
            [PropertyOrder(6)]
            [PropertyDisplay(true)]
            public string? Comment { get; init; } = null;
        }
        public record QualificationImprovedEmployeeResponse 
        {
            #nullable disable
            [PropertyDisplay(false)]
            [PropertyOrder(0)]
            public int Id { get; init; }
            
            [PropertyDisplay(true)]
            [PropertyOrder(1)]
            public string FullName { get; init; }

            [PropertyDisplay(true)]
            [PropertyOrder(2)]
            public string Position { get; init; }

            [PropertyDisplay(true)]
            [PropertyOrder(3)]
            public string CourseName { get; init; }

            [PropertyDisplay(true)]
            [PropertyOrder(4)]
            public string EducationPeriod { get; init; }

            [PropertyDisplay(true)]
            [PropertyOrder(5)]
            public string CourseConductedOrgName { get; init; }

            [PropertyDisplay(false)]
            [PropertyOrder(0)]
            public int OrgMonitoringId { get; init; }
                
            [PropertyDisplay(true)]
            [PropertyOrder(6)]
            public int FileId { get; init; }
        } 

        public record QuestionBlockResponse(int BlockId, string BlockNumber, string BlockName,int MaxScore, 
                                                int? SectionCount=null, double? Completion = null, double? Score = null, int? EvaluationId = null);
        public record RawQuestionBlockResponse(int BlockId, string BlockNumber, string BlockName, bool IsActive,
                                                int MaxScore, int? SectionCount = null);
        public record FormSectionResponse 
        {
            public int SectionId { get; init; }
            public string SectionName { get; init; }
            public string SectionNumber { get; init; }
            public int QuestionBlockId { get; init; }
            public bool IsActive { get; init; }
            public bool IsFilled { get; set; } = false;
            public int NumberOfItems { get; set; }
        }
        public record OrganizationResponse(int OrganizationId, string FullName, bool Status, string ShortName, string HeadFullName, string RegulatoryLegalAct,
            string Address, string PhoneNumber, string Email, string Fax, string EXat, int NumberOfEmployees);
        public record OrgShortInfoResponse(int OrganizationId, string FullName);
        public record MonitoringIndicatorWithQbsResponse(int Id, string Name, IEnumerable<QuestionBlockResponse> QuestionBlocks);
        public record MonitoringIndicatorResponse(int Id, string Name, bool IsActive, int QbCount);
        public record ScoreResponse(string Discriminator, double? Score, DateTime? EvaluatedTime, string Comment = null, bool IsEvaluated = false, int? BlockMaxScore = null); //Discriminator could be Organization Name or Quesiton Block Name
        public class RankingResponse 
        {
            public int OrganizationId { get; set; }
            public string OrganizationName { get; set; }
            public double? Score { get; set; }
            public double Completion { get; set; }
            public int NumberOfEvaluatedQbs { get; set; }
            public int NumberOfQbs { get; set; }
            public Period Period { get; set; }

            public RankingResponse(int orgId, string orgName, double? score, int numberOfQbs, Period period)
            {
                OrganizationId = orgId;
                OrganizationName = orgName;
                Score = score;
                NumberOfQbs = numberOfQbs;
                Period = period;
            }

            public RankingResponse(int orgId, double? score)
            {
                OrganizationId = orgId;
                Score = score;
            }

            public RankingResponse() { }
        } 
    }
}
