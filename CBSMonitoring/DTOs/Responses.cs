﻿using CBSMonitoring.Model;
using CBSMonitoring.Webframework;
using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.DTOs
{
    public class Responses
    {
        public record User(string? UserId, string? UserName, string? Email, bool IsActive, IEnumerable<string> Roles, string? FullName, string OrganizationName, int OrganizationId, string Position, string? PhoneNumber);
        public class Sender
        {
            public string Id { get; set; }
            public string Name { get; set; }

            public Sender()
            {
                    
            }
        }
        public class Reciever 
        { 
            public string Id {  set; get; }
            public string Name { set; get; }
            public bool IsRead { set; get; }
            public Reciever() { }
        
        }
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
        //public record LoginResponse(string? Token, string? UserName, IList<string>? UserRoles, bool IsFirstLogin);
        public record AuthResponse(string UserName, bool IsFirstLogin, bool Require2Fa, string? Token = null, IList<string>? UserRoles = null);
        public class RegistrationResponse
        {
            #nullable disable
            public string UserName { get; init; }
            public string Email { get; init; }
            public string FullName { get; init; }
            public string OrganizationName { get; set; }
            public List<string> Roles { get; init; }
            #nullable enable
            public string? Position { get; init; } = null;
            public string? PhoneNumber { get; init; } = null;
        }
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
            public string? Comments { get; init; }
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
                                                int? SectionCount=null, double? Completion = null, double? Score = null, int? EvaluationId = null, string Comment = null, 
                                                bool HasAnyReportAfterEvaluation = false, int NumberOfReportsAfterEvaluation = 0);
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
        public record MonitoringIndicatorWithRawQbsResponse(int Id, string Name, IEnumerable<RawQuestionBlockResponse> QuestionBlocks);
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
        public class ScoreStatsReponse
        {
            public int OrganizationId { get; init; }
            public string OrganizationName { get; init; }
            public List<ScoreForPeriod> Scores { get; init; }
        }
        public record StatsForCertainCriteriaResponse(IEnumerable<string> Orgs, Period Period);
        public record StatsForReportCompletionResponse(int OrganizationId, string OrganizationName, IEnumerable<CompletionForPeriod> CompletionPercentages);

        public class InboxMessage
        {
            public int Id { get; set; }
            public Sender Sender { get; set; }
            public string Content { get; set; }
            public bool IsBroadcast { get; set; }
            public DateTime TimeStamp { get; set; }
            public bool IsRead { get; set; }
            public InboxMessage()
            {

            }
        }
        //public  InboxMessage(int Id, Sender Sender, string Content, bool IsBroadcast, DateTime TimeStamp, bool IsRead = true);
        public record SentMessage 
        { 
            public int Id { get; set; }
            public string Content { get; set; }
            public bool IsBroadcast { get; set; }
            public DateTime TimeStamp { get; set; }
            public List<Reciever> Recievers { get; set; }

            public SentMessage()
            {
                
            }

        } //(int Id, string Content, bool IsBroadcast, DateTime TimeStamp, List<Reciever> Recievers);
        public record CatalogResponse(int Id, string Name, string Description);
    }
}
