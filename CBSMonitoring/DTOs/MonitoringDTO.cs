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
        public int OrganizationId { get; set; }
        public int QuarterIndex { get; set; }
        public int Year { get; set; }
        public string? SectionNumber { get; set; } = null;

        #region Forms

        #region form 1.1
        /// <form>1.1.1</form>
        public bool? HasPolicy { get; set; } = null;

        /// <form>1.1.2</form>
        public bool? IsReviewedByCBS { get; set; } = null;

        /// <form>1.1.3</form>
        public bool? AgreedWithAuthBody { get; set; } = null;

        /// <form>1.1.4</form>
        public bool? AreEmpsFamiliarWithISP { get; set; } = null;

        public int? NumberOfEmployees { get; set; } = null;
        public float? PercentageOfEmpFamiliarWithPolicy { get; set; } = null;

        /// <form>1.1.5</form>
        public bool? IsAuditConducted { get; set; } = null;

        /// <form>1.1.6</form>
        public bool? HasISPRevised { get; set; } = null;

        public int? NumberOfRevision { get; set; } = null;
        public int? YearOfRevisions { get; set; } = null;
        #endregion

        #region Form 1.2

        /// <form>1.2.1</form>
        public bool? AreInternalRegulationsAvailable { get; set; } = null;

        public int? NumberOfRegDocs { get; set; } = null;
        public string? ListOfRegDocs { get; set; } = null;
        #endregion

        #region Form 1.3
        /// <form>1.3.1</form>
        public bool? AreRegsAndRecordsAvailable { get; set; }
        public int? NumberOfRegAndRecords { get; set; }
        public string? ListOfRegAndRecords { get; set; }
        #endregion

        #region Form 1.4
        /// <form>1.4.1</form>
        public bool? IsListOfConfInfoAvailable { get; set; }
        public string? ConfidentialDocNumber { get; set; }
        public DateTime? ConfidentialDocDate { get; set; }
        /// <form>1.4.2</form>
        public bool? IsComissionPresent { get; set; }
        public string? ComissionDocNumber { get; set; }
        public DateTime? ComissionDocDate { get; set; }
        /// <form>1.4.3</form>
        public bool? IsListOfOfficialAvailable { get; set; }
        public string? OfficialsDocNumber { get; set; }
        public DateTime? OfficialsDocDate { get; set; }
        /// <form>1.4.4</form>
        public bool? IsListOfConfInfoProvidedToEmps { get; set; }
        #endregion

        #region Form 1.5
        /// <form>1.5.1</form>
        public bool? IsAgreementOnPrivacyAvailable { get; set; }
        /// <form>1.5.2</form>
        public bool? IsRelevantClausesAvailable { get; set; }
        /// <form>1.5.3</form>
        public bool? IsEmployeesFamWithAgreements { get; set; }
        public int? NumberOfEmplFamWithAgreements { get; set; }
        public float? PercentageOfEmpFamWithAgreements { get; set; }
        #endregion

        #region Form 2.1
        /// <form>2.1.1</form>
        public bool? IsActionPlanAvailableToEnsIC { get; set; }
        public string? ReasonForAbsenceOfPlan { get; set; }
        /// <form>2.1.2</form>
        public bool? IsActionPlanAgreedToEnsIC { get; set; }
        public string? ReasonForAbsenceOfAgreement { get; set; }

        #endregion

        #region Form 2.2

        /// <form>2.2.1</form>
        public int? NumberOfSectsInActionPlan { get; set; } = null;

        public int? NumberOfDoneSects { get; set; } = null;
        public int? NumberOfDoneSectsInTime { get; set; } = null;

        /// <form>2.2.2</form>
        public ICollection<TimelyExecutionOfPlanRequest>? TimelyExecutionOfPlans { get; set; } = null;

        #endregion

        #region Form 2.3

        /// <form>2.3.1</form>
        public bool? IsListOfProtectedObjAvailable { get; set; } = null;

        /// <form>2.3.2</form>
        public bool? IsObjectsClassified { get; set; } = null;

        /// <form>2.3.3</form>
        public bool? IsISystemAvailable { get; set; } = null;

        public string? NamesOfISystems { get; set; } = null;

        /// <form>2.3.4</form>
        public bool? IsISystemResourcesAvailable { get; set; } = null;

        public string? NamesOfSystemResources { get; set; } = null;
        #endregion

        #region Form 2.4

        /// <form>2.4.1</form>
        public bool? IsISecDivisionPresent { get; set; } = null;

        public string? ISsecDivisionName { get; set; } = null;

        /// <form>2.4.2</form>
        public bool? IsDevisionPositionPresent { get; set; } = null;

        public string? SectionHeadFullName { get; set; } = null;
        public string? PositionOfSectionHead { get; set; } = null;
        public string? PhoneNumOfSectionHead { get; set; } = null;
        public string? EmailOfSectionHead { get; set; } = null;
        public int? NumberOfISEmployees { get; set; } = null;
        /// <form>2.4.3</form>
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; set; } = null;
        public string? NameOfOutSourcingOrg { get; set; } = null;
        public string? ContractNumberOfOutsoucingOrg { get; set; } = null;
        public DateTime? ContractDateOfOutsoucingOrg { get; set; } = null;
        public string? ListOfServicesOfOutsourcingOrg { get; set; } = null;
        #endregion

        #region Form 2.5
        /// <form>2.5.1</form>
        public bool? IsResponsiblePersonAssigned { get; set; } = null;
        public string? FullNameOfRespPerSon { get; set; } = null;
        public string? PositionOfRespPerson { get; set; } = null;
        public string? TelNumOfRespPerson { get; set; } = null;
        public string? EmailOfRespPerson { get; set; } = null;

        #endregion

        #region Form 2.6
        /// <form>2.6.1</form>
        public bool? IsRespPersonAvailableForSecIssues { get; set; } = null;
        public string? FullNameOfRespPersonForSecIssues { get; set; } = null;
        public string? PositionOfRespPersonForSecIssues { get; set; } = null;
        public string? TelNumberOfRespPersonForSecIssues { get; set; } = null;
        public string? EmailOfRespPersonForSecIssues { get; set; } = null;

        #endregion

        #region Form 2.7
        /// <form>2.7.1</form>
        public bool? IsInstructionPresent { get; set; } = null;
        public int? PositionInstructionCount { get; set; } = null;

        #endregion

        #region Form 2.8
        ///<form>2.8.1</form>
        public bool? IsEmpsQualificationImproved { get; set; } = null;
        public int? NumberOfEmpsQualificaitonImproved { get; set; } = null;
        public ICollection<QualificationImprovedEmployeeRequest>? QualificationImprovedEmployees { get; set; } = null;
        #endregion

        #region Form 2.9
        ///<form>2.9.1</form>
        public string? WebAddress { get; set; } = null;
        public string? ExpertizingPeriod { get; set; } = null;
        public string? ExpertConclusionNumber { get; set; } = null;
        public DateTime? ExpertConclusionDate { get; set; } = null;
        public bool? HasShortcomings { get; set; } = null;
        public bool? IsShortcomingsOfWebsiteEliminated { get; set; } = null;
        #endregion

        #region Form 2.10
        ///<form>2.10.1</form>
        public bool? IsObjectsAudited { get; set; } = null;
        public string? AuditedObjectsNames { get; set; } = null;
        public string? OrgNameMadeAudit { get; set; } = null;
        public string? AuditPeriod { get; set; } = null;
        public string? NumberOfAuditConc { get; set; } = null;
        public DateTime? AuditConcDate { get; set; } = null;
        public bool? IsShortcomingDetected { get; set; } = null;
        public bool? IsShortcomingsOfObjecttEliminated { get; set; } = null;
        #endregion

        #region Form 2.11
        ///<form>2.11.1</form>
        public bool? IsEntranceSecurityAvailable { get; set; } = null;
        public int? NumberOfObjWithSecurity { get; set; } = null;
        ///<form>2.11.2</form>
        public bool? IsACSAvialble { get; set; } = null;
        public int? NumberOfObjInACS { get; set; } = null;
        ///<form>2.11.3</form>
        public bool? IsCheckInOutLogAvailable { get; set; } = null;
        public int? NumberOfPointsInLog { get; set; } = null;
        ///<form>2.11.4</form>
        public bool? IsSurveillanceCamerasAvailable { get; set; } = null;
        public int? NumberOfVideoCamsInCentre { get; set; } = null;
        public int? NumberOfStructObjsWithCams { get; set; } = null;
        public int? NumberOfVideoCamsInTerritorialObjs { get; set; } = null;
        ///<form>2.11.5</form>
        public bool? IsSecAlarmsInCentreAvailable { get; set; } = null;
        public int? NumberOfRoomsMonitoredByAlarms { get; set; } = null;
        public int? NumberOfTerritObjsWithAlarms { get; set; } = null;
        ///<form>2.11.6</form>
        public bool? IsServerRoomOrDataCenterAvailable { get; set; } = null;
        public int? NumberOfServerRoom { get; set; } = null;
        public int? NumberOfDataCentre { get; set; } = null;
        public int? NumberOfSRandDCWithMetalDoor { get; set; } = null;
        public int? NumberOfSRandDCWithWithSystemControl { get; set; } = null;
        public bool? IsCoolingSystemAvailable { get; set; } = null;
        public bool? IsAntiFireEquipAvailable { get; set; } = null;
        public bool? IsPlanForPreventiveMaintAvailable { get; set; } = null;
        public bool? IsVideoCamAvailable { get; set; } = null;
        public bool? IsFalseFloorAndCeilingAvailable { get; set; } = null;
        public bool? IsTempSensorsAvailable { get; set; } = null;
        public bool? IsLogsForSRAndDCEntrance { get; set; } = null;
        ///<form>2.11.7</form>
        public bool? IsSealedOuterCaseAvailable { get; set; } = null;
        public int? NumberOfServersWithSealedOuterCases { get; set; } = null;
        public int? NumberOfWStWithSealedOuterCases { get; set; } = null;
        #endregion

        #region Form 2.12
        ///<form>2.12.1</form>
        public bool? IsLogsForIncidentsAvailable { get; set; } = null;
        public int? NumberOfObjWithIncidentLog { get; set; } = null;
        public bool? IsDepISAndHeadNotified { get; set; } = null;
        public bool? IsIncidentsInvestigated { get; set; } = null;
        public bool? IsAnyIncidentResoluted { get; set; } = null;
        public int? NumberOfIncidents { get; set; } = null;
        public int? NumOfIncidentsInStructOrg { get; set; } = null;
        public int? NumOfIncidentsInSubObjects { get; set; } = null;
        public int? NumOfIncidentsInvestigated { get; set; } = null;
        public int? NumOFIncidentsResoluted { get; set; } = null;
        #endregion

        #region Form 2.13
        ///<form>2.13.1</form>
        public bool? IsBackupMeasuresProvided { get; set; } = null;
        public int? NumOfISBackupProvided { get; set; } = null;
        public int? NumOfConfidentialInfo { get; set; } = null;
        public string? BackupFrequency { get; set; } = null;
        public int? NumOfServersSoftRedundancyMeasured { get; set; } = null;
        public bool? IsApprovedScheduleForBackupAvailable { get; set; } = null;
        #endregion

        #region Form 2.14
        ///<form>2.14.1</form>
        public int? NumOfServersWithLicensedOS { get; set; } = null;
        public int? NumOfServersWithUpdatingOs { get; set; } = null;
        public int? NumOfWRoomswihLicensedOS { get; set; } = null;
        #endregion

        #region Form 2.15
        ///<form>2.15.1</form>
        public bool? IsPlannedPrevWorkAvailable { get; set; } = null;
        public string? FrequencyOfPrevMaintanence { get; set; } = null;
        #endregion

        #region Form 2.16
        ///<form>2.16.1</form>
        public bool? IsRecoveryPlansAvailable { get; set; } = null;
        #endregion

        #region Form 2.17
        ///<form>2.17.1</form>
        public bool? IsFireAlarmSystAvailable { get; set; } = null;
        public bool? IsGasFireExtSystAvailable { get; set; } = null;
        public bool? IsUPSForSEqAvailable { get; set; } = null;
        public int? NumberOfServersWithUPS { get; set; } = null;
        public bool? IsUPSAvailableForWRs { get; set; } = null;
        public int? NumberOfWRsWithUPS { get; set; } = null;
        public bool? IsAlternativePowerLAvailable { get; set; } = null;
        public bool? IsGeneratorsAvailable { get; set; } = null;
        public int? NumberOfGenerators { get; set; } = null;
        #endregion

        #region Form 2.18
        ///<form>2.18.1</form>
        public bool? IsLogsOfCarriersOfConfInfAvailable { get; set; } = null;
        #endregion

        #region Form 3.1
        ///<form>3.1.1</form>
        public bool? IsPasswProtectInWRsAvailable { get; set; } = null;
        public int? NumberOfWRsWithPasswProtection { get; set; } = null;
        public string? FrequencyOfPasswUpdateInWRs { get; set; } = null;
        ///<form>3.1.2</form>
        public bool? IsPasswProtectInSRsAvailable { get; set; } = null;
        public int? NumberOfSRsWithPasswProtection { get; set; } = null;
        public string? FrequncyOfPasswUpdateInSRs { get; set; } = null;
        #endregion

        #region Form 3.2
        ///<form>3.2.1</form>
        public bool? IsACToNetInCentreAvailable { get; set; } = null;
        public string? NameOfToolForACInCentre { get; set; } = null;
        ///<form>3.2.2</form>
        public bool? IsACToNetInStrucDivAvailable { get; set; } = null;
        public int? NumOfOrgsWithACToNetInStrucDiv { get; set; } = null;
        public string? NameOfToolsForACInStrucDiv { get; set; } = null;
        #endregion

        #region Form 3.3
        ///<form>3.3.1</form>
        public bool? IsAccessControlSystemAvailable { get; set; } = null;
        public int? NumberOfISWithACS { get; set; } = null;
        public int? NumberOfISWithOnlyPassw { get; set; } = null;
        public int? NumberOfISWithCryptKeys { get; set; } = null;
        public int? NumberOfISWithConfInfUsingACS { get; set; } = null;
        public int? NumberOfISWithConfInfWithOnlyPassw { get; set; } = null;
        public int? NumberOfISWithConfInfWithCryptKeys { get; set; } = null;
        public string? NameOfACMTool { get; set; } = null;
        public string? UserIDsInAccess { get; set; } = null;
        public bool? IsAccessEventsAndLogsRecorded { get; set; } = null;
        public string? FrequencyOfIDsChange { get; set; } = null;
        #endregion

        #region Form 3.4
        ///<form>3.4.1</form>
        public bool? IsAnitivirusAvailable { get; set; } = null;
        public string? NameAndVersionOfAntivirus { get; set; } = null;
        public bool? IsLicenseForAntivirusAvailable { get; set; } = null;
        public int? NumberOfServersWithAntivirus { get; set; } = null;
        public int? NumberOfWRsWithAntivirus { get; set; } = null;
        #endregion

        #region Form 3.5
        ///<form>3.5.1</form>
        public bool? IsFirewallAvailable { get; set; } = null;
        public string? NameAndVersionOfFirewall { get; set; } = null;
        public bool? IsLicenceForFireWallAvailable { get; set; } = null;
        #endregion

        #region Form 3.6
        ///<form>3.6.1</form>
        public bool? IsIDPSAvailable { get; set; } = null;
        public string? NameAndVersionOfIDPS { get; set; } = null;
        public bool? IsLicenseForIDPSAvailable { get; set; } = null;
        #endregion

        #region Form 3.7
        ///<form>3.7.1</form>
        public bool? IsEXATAvailable { get; set; } = null;
        public int? NumberOfSystemsWithEXAT { get; set; } = null;
        #endregion

        #region Form 3.8
        ///<form>3.8.1</form>
        public bool? IsHUMOAvailable { get; set; } = null;
        public int? NumberOfsystemsWithHUMO { get; set; } = null;
        #endregion

        #region Form 3.9
        ///<form>3.9.1</form>
        public bool? IsVPNUsed { get; set; } = null;
        public string? PurposeAndScopeOfVPNConnections { get; set; } = null;
        #endregion

        #region Form 3.10
        ///<form>3.10.1</form>
        public bool? IsDLPAvailable { get; set; } = null;
        public string? NameAndVersionOfDLP { get; set; } = null;
        public bool? IsLicenceOfDLPAvaliable { get; set; } = null;
        public int? NumberOfWorkRoomsWithDLP { get; set; } = null;
        #endregion

        #region Form 3.11
        ///<form>3.11.1</form>
        public bool? IsSIEMAvailable { get; set; } = null;
        public string? NameAndVersionOfSIEM { get; set; } = null;
        public bool? IsLicenseForSIEMAvailable { get; set; } = null;
        #endregion

        #region Form 3.12
        ///<form>3.12.1</form>
        public bool? IsCAndAnalysisToolAvailable { get; set; } = null;
        public string? NameAndVersionOfCAndSAnalysisTool { get; set; } = null;
        public string? PurposeOfCAndSAnalysisTools { get; set; } = null;
        public string? NumberOfCAndSAnalysisTools { get; set; } = null;
        #endregion

        #region Form 3.13
        ///<form>3.13.1</form>
        public bool? IsProtectionToolAvailable { get; set; } = null;
        public string? NameOfProtectionTool { get; set; } = null;
        public string? PurposeOfProtectionTool { get; set; } = null;
        public int? NumberOfProtectionTool { get; set; } = null;
        #endregion

        #endregion
    }

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
