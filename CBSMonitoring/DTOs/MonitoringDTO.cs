using CBSMonitoring.Helpers;
using CBSMonitoring.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.DTOs
{
    //[ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "json")]
    public class MonitoringDto
    {
        public int OrganizationId { get; init; }
        public int QuarterIndex { get; init; } = (DateTime.Now.Month - 1) / 3 + 1;
        public int Year { get; init; } = DateTime.Now.Year;
        //public string? SectionNumber { get;} = null;
        public string? DocNumber { get; init; }
        public DateTime? DocDate { get; init; }

        #region Forms

        #region form 1.1
        /// <form>1.1.1</form>
        public bool? HasPolicy { get; init; } = null;

        /// <form>1.1.2</form>
        public bool? IsReviewedByCBS { get; init; } = null;

        /// <form>1.1.3</form>
        public bool? AgreedWithAuthBody { get; init; } = null;

        /// <form>1.1.4</form>
        public bool? AreEmpsFamiliarWithISP { get; init; } = null;

        public int? NumberOfEmployees { get; init; } = null;
        public float? PercentageOfEmpFamiliarWithPolicy { get; init; } = null;

        /// <form>1.1.5</form>
        public bool? IsAuditConducted { get; init; } = null;

        /// <form>1.1.6</form>
        public bool? HasISPRevised { get; init; } = null;

        public int? NumberOfRevision { get; init; } = null;
        public int? YearOfRevisions { get; init; } = null;
        #endregion

        #region Form 1.2

        /// <form>1.2.1</form>
        public bool? AreInternalRegulationsAvailable { get; init; } = null;

        public int? NumberOfRegDocs { get; init; } = null;
        public string? ListOfRegDocs { get; init; } = null;
        #endregion

        #region Form 1.3
        /// <form>1.3.1</form>
        public bool? AreRegsAndRecordsAvailable { get; init; } = null;
        public int? NumberOfRegAndRecords { get; init; } = null;
        public string? ListOfRegAndRecords { get; init; } = null;
        #endregion

        #region Form 1.4
        /// <form>1.4.1</form>
        public bool? IsListOfConfInfoAvailable { get; init; } = null;
        public string? ConfidentialDocNumber { get; init; } = null;
        public DateTime? ConfidentialDocDate { get; init; } = null;
        /// <form>1.4.2</form>
        public bool? IsComissionPresent { get; init; } = null;
        public string? ComissionDocNumber { get; init; } = null;
        public DateTime? ComissionDocDate { get; init; } = null;
        /// <form>1.4.3</form>
        public bool? IsListOfOfficialAvailable { get; init; }
        public string? OfficialsDocNumber { get; init; } = null;
        public DateTime? OfficialsDocDate { get; init; } = null;
        /// <form>1.4.4</form>
        public bool? IsListOfConfInfoProvidedToEmps { get; init; } = null;
        #endregion

        #region Form 1.5
        /// <form>1.5.1</form>
        public bool? IsAgreementOnPrivacyAvailable { get; init; } = null;
        /// <form>1.5.2</form>
        public bool? IsRelevantClausesAvailable { get; init; } = null;
        /// <form>1.5.3</form>
        public bool? IsEmployeesFamWithAgreements { get; init; } = null;
        public int? NumberOfEmplFamWithAgreements { get; init; } = null;
        public float? PercentageOfEmpFamWithAgreements { get; init; } = null;
        #endregion

        #region Form 2.1
        /// <form>2.1.1</form>
        public bool? IsActionPlanAvailableToEnsIC { get; init; } = null;
        public string? ReasonForAbsenceOfPlan { get; init; } = null;
        /// <form>2.1.2</form>
        public bool? IsActionPlanAgreedToEnsIC { get; init; } = null;
        public string? ReasonForAbsenceOfAgreement { get; init; } = null;

        #endregion

        #region Form 2.2

        /// <form>2.2.1</form>
        public int? NumberOfSectsInActionPlan { get; init; } = null;

        public int? NumberOfDoneSects { get; init; } = null;
        public int? NumberOfDoneSectsInTime { get; init; } = null;

        /// <form>2.2.2</form>
        public ICollection<TimelyExecutionOfPlanRequest>? TimelyExecutionOfPlans { get; init; } = null;

        #endregion

        #region Form 2.3

        /// <form>2.3.1</form>
        public bool? IsListOfProtectedObjAvailable { get; init; } = null;

        /// <form>2.3.2</form>
        public bool? IsObjectsClassified { get; init; } = null;

        /// <form>2.3.3</form>
        public bool? IsISystemAvailable { get; init; } = null;

        public string? NamesOfISystems { get; init; } = null;

        /// <form>2.3.4</form>
        public bool? IsISystemResourcesAvailable { get; init; } = null;

        public string? NamesOfSystemResources { get; init; } = null;
        #endregion

        #region Form 2.4

        /// <form>2.4.1</form>
        public bool? IsISecDivisionPresent { get; init; } = null;

        public string? ISsecDivisionName { get; init; } = null;

        /// <form>2.4.2</form>
        public bool? IsDevisionPositionPresent { get; init; } = null;

        public string? SectionHeadFullName { get; init; } = null;
        public string? PositionOfSectionHead { get; init; } = null;
        public string? PhoneNumOfSectionHead { get; init; } = null;
        public string? EmailOfSectionHead { get; init; } = null;
        public int? NumberOfISEmployees { get; init; } = null;
        /// <form>2.4.3</form>
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; init; } = null;
        public string? NameOfOutSourcingOrg { get; init; } = null;
        public string? ContractNumberOfOutsoucingOrg { get; init; } = null;
        public DateTime? ContractDateOfOutsoucingOrg { get; init; } = null;
        public string? ListOfServicesOfOutsourcingOrg { get; init; } = null;
        #endregion

        #region Form 2.5
        /// <form>2.5.1</form>
        public bool? IsResponsiblePersonAssigned { get; init; } = null;
        public string? FullNameOfRespPerSon { get; init; } = null;
        public string? PositionOfRespPerson { get; init; } = null;
        public string? TelNumOfRespPerson { get; init; } = null;
        public string? EmailOfRespPerson { get; init; } = null;

        #endregion

        #region Form 2.6
        /// <form>2.6.1</form>
        public bool? IsRespPersonAvailableForSecIssues { get; init; } = null;
        public string? FullNameOfRespPersonForSecIssues { get; init; } = null;
        public string? PositionOfRespPersonForSecIssues { get; init; } = null;
        public string? TelNumberOfRespPersonForSecIssues { get; init; } = null;
        public string? EmailOfRespPersonForSecIssues { get; init; } = null;

        #endregion

        #region Form 2.7
        /// <form>2.7.1</form>
        public bool? IsInstructionPresent { get; init; } = null;
        public int? PositionInstructionCount { get; init; } = null;

        #endregion

        #region Form 2.8
        ///<form>2.8.1</form>
        public bool? IsEmpsQualificationImproved { get; init; } = null;
        public int? NumberOfEmpsQualificaitonImproved { get; init; } = null;
        public ICollection<QualificationImprovedEmployeeRequest>? QualificationImprovedEmployees { get; init; } = null;
        #endregion

        #region Form 2.9
        ///<form>2.9.1</form>
        public string? WebAddress { get; init; } = null;
        public string? ExpertizingPeriod { get; init; } = null;
        public string? ExpertConclusionNumber { get; init; } = null;
        public DateTime? ExpertConclusionDate { get; init; } = null;
        public bool? HasShortcomings { get; init; } = null;
        public bool? IsShortcomingsOfWebsiteEliminated { get; init; } = null;
        #endregion

        #region Form 2.10
        ///<form>2.10.1</form>
        public bool? IsObjectsAudited { get; init; } = null;
        public string? AuditedObjectsNames { get; init; } = null;
        public string? OrgNameMadeAudit { get; init; } = null;
        public string? AuditPeriod { get; init; } = null;
        public string? NumberOfAuditConc { get; init; } = null;
        public DateTime? AuditConcDate { get; init; } = null;
        public bool? IsShortcomingDetected { get; init; } = null;
        public bool? IsShortcomingsOfObjecttEliminated { get; init; } = null;
        #endregion

        #region Form 2.11
        ///<form>2.11.1</form>
        public bool? IsEntranceSecurityAvailable { get; init; } = null;
        public int? NumberOfObjWithSecurity { get; init; } = null;
        ///<form>2.11.2</form>
        public bool? IsACSAvialble { get; init; } = null;
        public int? NumberOfObjInACS { get; init; } = null;
        ///<form>2.11.3</form>
        public bool? IsCheckInOutLogAvailable { get; init; } = null;
        public int? NumberOfPointsInLog { get; init; } = null;
        ///<form>2.11.4</form>
        public bool? IsSurveillanceCamerasAvailable { get; init; } = null;
        public int? NumberOfVideoCamsInCentre { get; init; } = null;
        public int? NumberOfStructObjsWithCams { get; init; } = null;
        public int? NumberOfVideoCamsInTerritorialObjs { get; init; } = null;
        ///<form>2.11.5</form>
        public bool? IsSecAlarmsInCentreAvailable { get; init; } = null;
        public int? NumberOfRoomsMonitoredByAlarms { get; init; } = null;
        public int? NumberOfTerritObjsWithAlarms { get; init; } = null;
        ///<form>2.11.6</form>
        public bool? IsServerRoomOrDataCenterAvailable { get; init; } = null;
        public int? NumberOfServerRoom { get; init; } = null;
        public int? NumberOfDataCentre { get; init; } = null;
        public int? NumberOfSRandDCWithMetalDoor { get; init; } = null;
        public int? NumberOfSRandDCWithWithSystemControl { get; init; } = null;
        public bool? IsCoolingSystemAvailable { get; init; } = null;
        public bool? IsAntiFireEquipAvailable { get; init; } = null;
        public bool? IsPlanForPreventiveMaintAvailable { get; init; } = null;
        public bool? IsVideoCamAvailable { get; init; } = null;
        public bool? IsFalseFloorAndCeilingAvailable { get; init; } = null;
        public bool? IsTempSensorsAvailable { get; init; } = null;
        public bool? IsLogsForSRAndDCEntrance { get; init; } = null;
        ///<form>2.11.7</form>
        public bool? IsSealedOuterCaseAvailable { get; init; } = null;
        public int? NumberOfServersWithSealedOuterCases { get; init; } = null;
        public int? NumberOfWStWithSealedOuterCases { get; init; } = null;
        #endregion

        #region Form 2.12
        ///<form>2.12.1</form>
        public bool? IsLogsForIncidentsAvailable { get; init; } = null;
        public int? NumberOfObjWithIncidentLog { get; init; } = null;
        public bool? IsDepISAndHeadNotified { get; init; } = null;
        public bool? IsIncidentsInvestigated { get; init; } = null;
        public bool? IsAnyIncidentResoluted { get; init; } = null;
        public int? NumberOfIncidents { get; init; } = null;
        public int? NumOfIncidentsInStructOrg { get; init; } = null;
        public int? NumOfIncidentsInSubObjects { get; init; } = null;
        public int? NumOfIncidentsInvestigated { get; init; } = null;
        public int? NumOFIncidentsResoluted { get; init; } = null;
        #endregion

        #region Form 2.13
        ///<form>2.13.1</form>
        public bool? IsBackupMeasuresProvided { get; init; } = null;
        public int? NumOfISBackupProvided { get; init; } = null;
        public int? NumOfConfidentialInfo { get; init; } = null;
        public string? BackupFrequency { get; init; } = null;
        public int? NumOfServersSoftRedundancyMeasured { get; init; } = null;
        public bool? IsApprovedScheduleForBackupAvailable { get; init; } = null;
        #endregion

        #region Form 2.14
        ///<form>2.14.1</form>
        public int? NumOfServersWithLicensedOS { get; init; } = null;
        public int? NumOfServersWithUpdatingOs { get; init; } = null;
        public int? NumOfWRoomswihLicensedOS { get; init; } = null;
        #endregion

        #region Form 2.15
        ///<form>2.15.1</form>
        public bool? IsPlannedPrevWorkAvailable { get; init; } = null;
        public string? FrequencyOfPrevMaintanence { get; init; } = null;
        #endregion

        #region Form 2.16
        ///<form>2.16.1</form>
        public bool? IsRecoveryPlansAvailable { get; init; } = null;
        #endregion

        #region Form 2.17
        ///<form>2.17.1</form>
        public bool? IsFireAlarmSystAvailable { get; init; } = null;
        public bool? IsGasFireExtSystAvailable { get; init; } = null;
        public bool? IsUPSForSEqAvailable { get; init; } = null;
        public int? NumberOfServersWithUPS { get; init; } = null;
        public bool? IsUPSAvailableForWRs { get; init; } = null;
        public int? NumberOfWRsWithUPS { get; init; } = null;
        public bool? IsAlternativePowerLAvailable { get; init; } = null;
        public bool? IsGeneratorsAvailable { get; init; } = null;
        public int? NumberOfGenerators { get; init; } = null;
        #endregion

        #region Form 2.18
        ///<form>2.18.1</form>
        public bool? IsLogsOfCarriersOfConfInfAvailable { get; init; } = null;
        #endregion

        #region Form 3.1
        ///<form>3.1.1</form>
        public bool? IsPasswProtectInWRsAvailable { get; init; } = null;
        public int? NumberOfWRsWithPasswProtection { get; init; } = null;
        public string? FrequencyOfPasswUpdateInWRs { get; init; } = null;
        ///<form>3.1.2</form>
        public bool? IsPasswProtectInSRsAvailable { get; init; } = null;
        public int? NumberOfSRsWithPasswProtection { get; init; } = null;
        public string? FrequncyOfPasswUpdateInSRs { get; init; } = null;
        #endregion

        #region Form 3.2
        ///<form>3.2.1</form>
        public bool? IsACToNetInCentreAvailable { get; init; } = null;
        public string? NameOfToolForACInCentre { get; init; } = null;
        ///<form>3.2.2</form>
        public bool? IsACToNetInStrucDivAvailable { get; init; } = null;
        public int? NumOfOrgsWithACToNetInStrucDiv { get; init; } = null;
        public string? NameOfToolsForACInStrucDiv { get; init; } = null;
        #endregion

        #region Form 3.3
        ///<form>3.3.1</form>
        public bool? IsAccessControlSystemAvailable { get; init; } = null;
        public int? NumberOfISWithACS { get; init; } = null;
        public int? NumberOfISWithOnlyPassw { get; init; } = null;
        public int? NumberOfISWithCryptKeys { get; init; } = null;
        public int? NumberOfISWithConfInfUsingACS { get; init; } = null;
        public int? NumberOfISWithConfInfWithOnlyPassw { get; init; } = null;
        public int? NumberOfISWithConfInfWithCryptKeys { get; init; } = null;
        public string? NameOfACMTool { get; init; } = null;
        public string? UserIDsInAccess { get; init; } = null;
        public bool? IsAccessEventsAndLogsRecorded { get; init; } = null;
        public string? FrequencyOfIDsChange { get; init; } = null;
        #endregion

        #region Form 3.4
        ///<form>3.4.1</form>
        public bool? IsAnitivirusAvailable { get; init; } = null;
        public string? NameAndVersionOfAntivirus { get; init; } = null;
        public bool? IsLicenseForAntivirusAvailable { get; init; } = null;
        public int? NumberOfServersWithAntivirus { get; init; } = null;
        public int? NumberOfWRsWithAntivirus { get; init; } = null;
        #endregion

        #region Form 3.5
        ///<form>3.5.1</form>
        public bool? IsFirewallAvailable { get; init; } = null;
        public string? NameAndVersionOfFirewall { get; init; } = null;
        public bool? IsLicenceForFireWallAvailable { get; init; } = null;
        #endregion

        #region Form 3.6
        ///<form>3.6.1</form>
        public bool? IsIDPSAvailable { get; init; } = null;
        public string? NameAndVersionOfIDPS { get; init; } = null;
        public bool? IsLicenseForIDPSAvailable { get; init; } = null;
        #endregion

        #region Form 3.7
        ///<form>3.7.1</form>
        public bool? IsEXATAvailable { get; init; } = null;
        public int? NumberOfSystemsWithEXAT { get; init; } = null;
        #endregion

        #region Form 3.8
        ///<form>3.8.1</form>
        public bool? IsHUMOAvailable { get; init; } = null;
        public int? NumberOfsystemsWithHUMO { get; init; } = null;
        #endregion

        #region Form 3.9
        ///<form>3.9.1</form>
        public bool? IsVPNUsed { get; init; } = null;
        public string? PurposeAndScopeOfVPNConnections { get; init; } = null;
        #endregion

        #region Form 3.10
        ///<form>3.10.1</form>
        public bool? IsDLPAvailable { get; init; } = null;
        public string? NameAndVersionOfDLP { get; init; } = null;
        public bool? IsLicenceOfDLPAvaliable { get; init; } = null;
        public int? NumberOfWorkRoomsWithDLP { get; init; } = null;
        #endregion

        #region Form 3.11
        ///<form>3.11.1</form>
        public bool? IsSIEMAvailable { get; init; } = null;
        public string? NameAndVersionOfSIEM { get; init; } = null;
        public bool? IsLicenseForSIEMAvailable { get; init; } = null;
        #endregion

        #region Form 3.12
        ///<form>3.12.1</form>
        public bool? IsCAndAnalysisToolAvailable { get; init; } = null;
        public string? NameAndVersionOfCAndSAnalysisTool { get; init; } = null;
        public string? PurposeOfCAndSAnalysisTools { get; init; } = null;
        public string? NumberOfCAndSAnalysisTools { get; init; } = null;
        #endregion

        #region Form 3.13
        ///<form>3.13.1</form>
        public bool? IsProtectionToolAvailable { get; init; } = null;
        public string? NameOfProtectionTool { get; init; } = null;
        public string? PurposeOfProtectionTool { get; init; } = null;
        public int? NumberOfProtectionTool { get; init; } = null;
        #endregion

        #endregion
    }
    public record DocInfo(string? DocNumber=null, DateTime? DocDate = null);
    public class FileItem
    {
        #nullable disable
        public IFormFile File { get;}
        public string Description { get;}
        #nullable enable
        public string? DocNumber { get;}
        public DateTime? DocDate { get; }

        public FileItem(IFormFile file, string description = "Файл", string? docNumber = null, DateTime? docDate = null)
        {
            File = file;
            Description = description;
            DocNumber = docNumber;
            DocDate = docDate;
        }
    }

}
