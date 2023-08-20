using CBSMonitoring.Models;
using CBSMonitoring.Models.Forms;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.DTOs
{
    public class MonitoringDTO
    {
        public int OrganizationId { get; set; }
        public int QuaterIndex { get; set; }
        public int Year { get; set; }
        public List<FileItem>? Files { get; set; }
        public int? FileId { get; set; }

        #region Forms

        #region form 1.1
        /// <form>1.1.1</form>
        public bool? HasPolicy { get; set; }
        public int? File_1_1_1Id { get; set; }
        /// <form>1.1.2</form>
        public bool? IsReviewedByCBS { get; set; }
        public int? File_1_1_2Id { get; set; }
        /// <form>1.1.3</form>
        public bool? AgreedWithAuthBody { get; set; }
        public int? File_1_1_3Id { get; set; }
        /// <form>1.1.4</form>
        public bool? AreEmpsFamiliarWithISP { get; set; }
        public int? NumberOfEmployees { get; set; }
        public float? PercentageOfEmpFamiliarWithPolicy { get; set; }
        /// <form>1.1.5</form>
        public bool? IsAuditConducted { get; set; }
        /// <form>1.1.6</form>
        public bool? HasISPRevised { get; set; }
        public int? NumberOfRevision { get; set; }
        public int? YearOfRevisions { get; set; }
        #endregion

        #region Form 1.2
        /// <form>1.2.1</form>
        public bool? AreInternalRegulationsAvailable { get; set; }
        public int? NumberOfRegDocs { get; set; }
        public string? ListOfRegDocs { get; set; }
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
        public int? NumberOfEmplFamWithAgreements { get; set; }
        public float? PercentageOfEmpFamWithAgreements { get; set; }
        #endregion

        #region Form 2.1
        /// <form>2.1.1</form>
        public bool? IsActionPlanAvailableToEnsIC { get; set; }
        public int? File_2_1_1Id { get; set; }
        public string? ReasonForAbsenceOfPlan { get; set; }
        /// <form>2.1.2</form>
        public bool? IsActionPlanAgreedToEnsIC { get; set; }
        public int? File_2_1_2Id { get; set; }
        public string? ReasonForAbsenceOfAgreement { get; set; }

        #endregion

        #region Form 2.2

        /// <form>2.2.1</form>
        public int[]? SectNumber { get; set; }
        public DateTime[]? DeadlineOfPlan { get; set; }
        public bool[]? IsExecuted { get; set; }
        public bool[]? DeadlineOfRealExec { get; set; }
        public int[]? File_2_2_1Ids { get; set; }

        #endregion

        #region Form 2.3
        /// <form>2.3.1</form>
        public bool? IsListOfProtectedObjAvailable { get; set; }
        public int? File_2_3_1Id { get; set; }
        /// <form>2.3.2</form>
        public bool? IsObjectsClasified { get; set; }
        public int? File_2_3_2Id { get; set; }
        /// <form>2.3.3</form>
        public bool? IsISystemAvailable { get; set; }
        public bool? IsISystemResourcesAvailable { get; set; }
        #endregion

        #region Form 2.4
        /// <form>2.4.1</form>
        public bool? IsISecDivisionPresent { get; set; }
        public string? ISsecDivisionName { get; set; }
        public bool? IsDevisionPositionPresent { get; set; }
        public string? SectionHeadFullName { get; set; }
        public string? PositionOfSectionHead { get; set; }
        public string? PhoneNumOfSectionHead { get; set; }
        public string? EmailOfSectionHead { get; set; }
        public int? NumberOfISEmployees { get; set; }
        /// <form>2.4.2</form>
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; set; }
        public string? NameOfOutSourcingOrg { get; set; }
        public string? ContractNumberOfOutsoucingOrg { get; set; }
        public DateTime? ContractDateOfOutsoucingOrg { get; set; }
        public string? ListOfServicesOfOutsourcingOrg { get; set; }
        #endregion

        #region Form 2.5
        /// <form>2.5.1</form>
        public bool? IsResponsiblePersonAssigned { get; set; }
        public string? FullNameOfRespPerSon { get; set; }
        public string? PositionOfRespPerson { get; set; }
        public string? TelNumOfRespPerson { get; set; }
        public string? EmailOfRespPerson { get; set; }

        #endregion

        #region Form 2.6
        /// <form>2.6.1</form>
        public bool? IsRespPersonAvailableForSecIssues { get; set; }
        public string? FullNameOfRespPersonForSecIssues { get; set; }
        public string? PositionOfRespPersonForSecIssues { get; set; }
        public string? TelNumberOfRespPersonForSecIssues { get; set; }
        public string? EmailOfRespPersonForSecIssues { get; set; }

        #endregion

        #region Form 2.7
        /// <form>2.7.1</form>
        public bool? IsInstructionPresent { get; set; }
        public int? PositionInstructionCount { get; set; }

        #endregion

        #region Form 2.8
        ///<form>2.8.1</form>
        public bool? IsEmpsQualificationImproved { get; set; }
        public int? NumberOfEmpsQualificaitonImproved { get; set; }
        //public int[]? QualifImpEmpIds { get; set; }
        public List<QualificationImprovedEmployee>? QualificationImprovedEmployees { get; set; }
        #endregion

        #region Form 2.9
        ///<form>2.9.1</form>
        public string? WebAddress { get; set; }
        public string? ExpertizingPeriod { get; set; }
        public string? ExpertConclusionNumber { get; set; }
        public DateTime? ExpertConclusionDate { get; set; }
        public bool? HasShortcomings { get; set; }
        public bool? IsShortcomingsOfWebsiteEliminated { get; set; }
        #endregion

        #region Form 2.10
        ///<form>2.10.1</form>
        public bool? IsObjectsAudited { get; set; }
        public string? AuditedObjectsNames { get; set; }
        public string? OrgNameMadeAudit { get; set; }
        public string? AuditPeriod { get; set; }
        public string? NumberOfAuditConc { get; set; }
        public DateTime? AuditConcDate { get; set; }
        public bool? IsShortcomingDetected { get; set; }
        public bool? IsShortcomingsOfObjecttEliminated { get; set; }
        #endregion

        #region Form 2.11
        ///<form>2.11.1</form>
        public bool? IsEntranceSecurityAvailable { get; set; }
        public int? NumberOfObjWithSecurity { get; set; }
        ///<form>2.11.2</form>
        public bool? IsACSAvialble { get; set; }
        public int? NumberOfObjInACS { get; set; }
        ///<form>2.11.3</form>
        public bool? IsCheckInOutLogAvailable { get; set; }
        public int? NumberOfPointsInLog { get; set; }
        ///<form>2.11.4</form>
        public bool? IsSurveillanceCamerasAvailable { get; set; }
        public int? NumberOfVideoCamsInCentre { get; set; }
        public int? NumberOfStructObjsWithCams { get; set; }
        public int? NumberOfVideoCamsInTerritorialObjs { get; set; }
        ///<form>2.11.5</form>
        public bool? IsSecAlarmsInCentreAvailable { get; set; }
        public int? NumberOfRoomsMonitoredByAlarms { get; set; }
        public int? NumberOfTerritObjsWithAlarms { get; set; }
        ///<form>2.11.6</form>
        public bool? IsServerRoomOrDataCenterAvailable { get; set; }
        public int? NumberOfServerRoom { get; set; }
        public int? NumberOfDataCentre { get; set; }
        public int? NumberOfSRandDCWithMetalDoor { get; set; }
        public int? NumberOfSRandDCWithWithSystemControl { get; set; }
        public bool? IsCoolingSystemAvailable { get; set; }
        public bool? IsAntiFireEquipAvailable { get; set; }
        public bool? IsPlanForPreventiveMaintAvailable { get; set; }
        public bool? IsVideoCamAvailable { get; set; }
        public bool? IsFalseFloorAndCeilingAvailable { get; set; }
        public bool? IsTempSensorsAvailable { get; set; }
        public bool? IsLogsForSRAndDCEntrance { get; set; }
        ///<form>2.11.7</form>
        public bool? IsSealedOuterCaseAvailable { get; set; }
        public int? NumberOfServersWithSealedOuterCases { get; set; }
        public int? NumberOfWStWithSealedOuterCases { get; set; }
        #endregion

        #region Form 2.12
        ///<form>2.12.1</form>
        public bool? IsLogsForIncidentsAvailable { get; set; }
        public int? NumberOfObjWithIncidentLog { get; set; }
        public bool? IsDepISAndHeadNotified { get; set; }
        public bool? IsIncidentsInvestigated { get; set; }
        public bool? IsAnyIncidentResoluted { get; set; }
        public int? NumberOfIncidents { get; set; }
        public int? NumOfIncidentsInStructOrg { get; set; }
        public int? NumOfIncidentsInSubObjects { get; set; }
        public int? NumOfIncidentsInvestigated { get; set; }
        public int? NumOFIncidentsResoluted { get; set; }
        #endregion

        #region Form 2.13
        ///<form>2.13.1</form>
        public bool? IsBackupMeasuresProvided { get; set; }
        public int? NumOfISBackupProvided { get; set; }
        public int? NumOfConfidentialInfo { get; set; }
        public string? BackupFrequency { get; set; }
        public int? NumOfServersSoftRedundancyMeasured { get; set; }
        public bool? IsApprovedScheduleForBackupAvailable { get; set; }
        #endregion

        #region Form 2.14
        ///<form>2.14.1</form>
        public int? NumOfServersWithLicensedOS { get; set; }
        public int? NumOfServersWithUpdatingOs { get; set; }
        public int? NumOfWRoomswihLicensedOS { get; set; }
        #endregion

        #region Form 2.15
        ///<form>2.15.1</form>
        public bool? IsPlannedPrevWorkAvailable { get; set; }
        public string? FrequencyOfPrevMaintanence { get; set; }
        #endregion

        #region Form 2.16
        ///<form>2.16.1</form>
        public bool? IsRecoveryPlansAvailable { get; set; }
        #endregion

        #region Form 2.17
        ///<form>2.17.1</form>
        public bool? IsFireAlarmSystAvailable { get; set; }
        public bool? IsGasFireExtSystAvailable { get; set; }
        public bool? IsUPSForSEqAvailable { get; set; }
        public int? NumberOfServersWithUPS { get; set; }
        public bool? IsUPSAvailableForWRs { get; set; }
        public int? NumberOfWRsWithUPS { get; set; }
        public bool? IsAlternativePowerLAvailable { get; set; }
        public bool? IsGeneratorsAvailable { get; set; }
        public int? NumberOfGenerators { get; set; }
        #endregion

        #region Form 2.18
        ///<form>2.18.1</form>
        public bool? IsLogsOfCarriersOfConfInfAvailable { get; set; }
        #endregion

        #region Form 3.1
        ///<form>3.1.1</form>
        public bool? IsPasswProtectInWRsAvailable { get; set; }
        public int? NumberOfWRsWithPasswProtection { get; set; }
        public string? FrequencyOfPasswUpdateInWRs { get; set; }
        ///<form>3.1.2</form>
        public bool? IsPasswProtectInSRsAvailable { get; set; }
        public int? NumberOfSRsWithPasswProtection { get; set; }
        public string? FrequncyOfPasswUpdateInSRs { get; set; }
        #endregion

        #region Form 3.2
        ///<form>3.2.1</form>
        public bool? IsACToNetInCentreAvailable { get; set; }
        public string? NameOfToolForACInCentre { get; set; }
        ///<form>3.2.2</form>
        public bool? IsACToNetInStrucDivAvailable { get; set; }
        public int? NumOfOrgsWithACToNetInStrucDiv { get; set; }
        public string? NameOfToolsForACInStrucDiv { get; set; }
        #endregion

        #region Form 3.3
        ///<form>3.3.1</form>
        public bool? IsAccessControlSystemAvailable { get; set; }
        public int? NumberOfISWithACS { get; set; }
        public int? NumberOfISWithOnlyPassw { get; set; }
        public int? NumberOfISWithCryptKeys { get; set; }
        public int? NumberOfISWithConfInfUsingACS { get; set; }
        public int? NumberOfISWithConfInfWithOnlyPassw { get; set; }
        public int? NumberOfISWithConfInfWithCryptKeys { get; set; }
        public string? NameOfACMTool { get; set; }
        public string? UserIDsInAccess { get; set; }
        public bool? IsAccessEventsAndLogsRecorded { get; set; }
        public string? FrequencyOfIDsChange { get; set; }
        #endregion

        #region Form 3.4
        ///<form>3.4.1</form>
        public bool? IsAnitivirusAvailable { get; set; }
        public string? NameAndVersionOfAntivirus { get; set; }
        public bool? IsLicenseForAntivirusAvailable { get; set; }
        public int? NumberOfServersWithAntivirus { get; set; }
        public int? NumberOfWRsWithAntivirus { get; set; }
        #endregion

        #region Form 3.5
        ///<form>3.5.1</form>
        public bool? IsFirewallAvailable { get; set; }
        public string? NameAndVersionOfFirewall { get; set; }
        public bool? IsLicenceForFireWallAvailable { get; set; }
        #endregion

        #region Form 3.6
        ///<form>3.6.1</form>
        public bool? IsIDPSAvailable { get; set; }
        public string? NameAndVersionOfIDPS { get; set; }
        public bool? IsLicenseForIDPSAvailable { get; set; }
        #endregion

        #region Form 3.7
        ///<form>3.7.1</form>
        public bool? IsEXATAvailable { get; set; }
        public int? NumberOfSystemsWithEXAT { get; set; }
        #endregion

        #region Form 3.8
        ///<form>3.8.1</form>
        public bool? IsHUMOAvailable { get; set; }
        public int? NumberOfsystemsWithHUMO { get; set; }
        #endregion

        #region Form 3.9
        ///<form>3.9.1</form>
        public bool? IsVPNUsed { get; set; }
        public string? PurposeAndScopeOfVPNConnections { get; set; }
        #endregion

        #region Form 3.10
        ///<form>3.10.1</form>
        public bool? IsDLPAvailable { get; set; }
        public string? NameAndVersionOfDLP { get; set; }
        public bool? IsLicenceOfDLPAvaliable { get; set; }
        public int? NumberOfWorkRoomsWithDLP { get; set; }
        #endregion

        #region Form 3.11
        ///<form>3.11.1</form>
        public bool? IsSIEMAvailable { get; set; }
        public string? NameAndVersionOfSIEM { get; set; }
        public bool? IsLicenseForSIEMAvailable { get; set; }
        #endregion

        #region Form 3.12
        ///<form>3.12.1</form>
        public bool? IsCAndAnalysisToolAvailable { get; set; }
        public string? NameAndVersionOfCAndSAnalysisTool { get; set; }
        public string? PurposeOfCAndSAnalysisTools { get; set; }
        public string? NumberOfCAndSAnalysisTools { get; set; }
        #endregion

        #region Form 3.13
        ///<form>3.13.1</form>
        public bool? IsProtectionToolAvailable { get; set; }
        public string? NameOfProtectionTool { get; set; }
        public string? PurposeOfProtectionTool { get; set; }
        public int? NumberOfProtectionTool { get; set; }
        #endregion

        #endregion
    }

    public class FileItem
    {
        #nullable disable
        public IFormFile File { get; set; }
        public string DocNumber { get; set; }
        public DateTime DocDate { get; set; }
        public string Description { get; set; }

    }
}
 