using CBSMonitoring.Models;

namespace CBSMonitoring.DTOs
{
    public class MonitoringDTO
    {
        public int OrganizationId { get; set; }
        public int QuaterIndex { get; set; }
        public int Year { get; set; }
        public List<FileModel>? Files { get; set; }

        /// <form>1.1</form>
        public bool? HasPolicy { get; set; }
        public bool? IsReviewedByCBS { get; set; }
        public int? NumberOfEmployees { get; set; }
        public float? PercentageOfEmpFamiliarWithPolicy { get; set; }
        public bool? IsAuditConducted { get; set; }
        public bool? HasISPRevised { get; set; }
        public int? NumberOfRevision { get; set; }
        public int? YearOfRevisions { get; set; }
        
        /// <form>1.2</form>
        public int? NumberOfRegDocs { get; set; }
        public string? ListOfRegDocs { get; set; }

        /// <form>1.3</form>
        public int? NumberOfRegJournal { get; set; }
        public string? ListOfRegJournal { get; set; }

        /// <form>1.4</form>
        public bool? IsListAvailable { get; set; }
        public string? ConfidentialDocNumber { get; set; }
        public DateTime? ConfidentialDocDate { get; set; }
        public bool? IsComissionPresent { get; set; }
        public string? ComissionDocNumber { get; set; }
        public DateTime? ComissionDocDate { get; set; }
        public bool? IsListOfOfficialAvailable { get; set; }
        public string? OfficialsDocNumber { get; set; }
        public DateTime? OfficialsDocDate { get; set; }
        public bool? IsListCommToEmps { get; set; }

        /// <form>1.5</form>
        public bool? IsAgreementsAvailable { get; set; }
        public bool? IsRelevantClausesAvailable { get; set; }
        public int? NumberOfEmplFamWithAgreements { get; set; }
        public float? PercentageOfEmpFamWithAgreements { get; set; }

        /// <form>2.1</form>
        public bool? IsActionPlanAvailableToEnsIC { get; set; }
        public string? ReasonForAbsenceOfPlan { get; set; }
        public bool? IsActionPlanAgreedToEnsIC { get; set; }
        public string? ReasonForAbsenceOfAgreement { get; set; }

        /// <form>2.2</form>
        public int? SectNumber { get; set; }
        public DateTime? DeadlineOfPlan { get; set; }
        public bool? IsExecuted { get; set; }
        public bool? DeadlineOfRealExec { get; set; }

        /// <form>2.3</form>
        public bool? IsListOfProtectedObjAvailable { get; set; }
        public bool? IsObjectsClasified { get; set; }
        public bool? IsISystemAvailable { get; set; }
        public bool? IsISystemResourcesAvailable { get; set; }

        /// <form>2.4</form>
        public bool? IsISecDivisionPresent { get; set; }
        public string? ISsecDivisionName { get; set; }
        public bool? IsDevisionPositionPresent { get; set; }
        public string? SectionHeadFullName { get; set; }
        public string? PositionOfSectionHead { get; set; }
        public string? PhoneNumOfSectionHead { get; set; }
        public string? EmailOfSectionHead { get; set; }
        public int? NumberOfISEmployees { get; set; }
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; set; }
        public string? NameOfOutSourcingOrg { get; set; }
        public string? ContractNumberOfOutsoucingOrg { get; set; }
        public DateTime? ContractDateOfOutsoucingOrg { get; set; }
        public string? ListOfServicesOfOutsourcingOrg { get; set; }

        /// <form>2.5</form>
        public bool? IsResponsiblePersonAssigned { get; set; }
        public string? FullNameOfRespPerSon { get; set; }
        public string? PositionOfRespPerson { get; set; }
        public string? TelNumOfRespPerson { get; set; }
        public string? EmailOfRespPerson { get; set; }

        /// <form>2.6</form>
        public bool? IsRespPersonAvailableForSecIssues { get; set; }
        public string? FullNameOfRespPersonForSecIssues { get; set; }
        public string? PositionOfRespPersonForSecIssues { get; set; }
        public string? TelNumberOfRespPersonForSecIssues { get; set; }
        public string? EmailOfRespPersonForSecIssues { get; set; }

        /// <form>2.7</form>
        public bool? IsInstructionPresent { get; set; }
        public int? PositionInstructionCount { get; set; }

        ///<form>2.8</form>
        public int? NumberOfEmpsQualificaitonImproved { get; set; }
        //public int[]? QualifImpEmpIds { get; set; }
        public List<QualificationImprovedEmployee>? QualificationImprovedEmployees { get; set; }

        ///<form>2.9</form>
        public string? WebAddress { get; set; }
        public string? ExpertizingPeriod { get; set; }
        public string? ExpertConclusionNumber { get; set; }
        public DateTime? ExpertConclusionDate { get; set; }
        public bool? HasShortcomings { get; set; }
        public bool? IsShortcomingsOfWebsiteEliminated { get; set; }

        ///<form>2.10</form>
        public bool? IsObjectsAudited { get; set; }
        public string? AuditedObjectsNames { get; set; }
        public string? OrgNameMadeAudit { get; set; }
        public string? AuditPeriod { get; set; }
        public string? NumberOfAuditConc { get; set; }
        public DateTime? AuditConcDate { get; set; }
        public bool? IsShortcomingDetected { get; set; }
        public bool? IsShortcomingsOfObjectEliminated { get; set; }

        ///<form>2.11</form>
        public bool? IsEntranceSecurityAvailable { get; set; }
        public int? NumberOfObjWithSecurity { get; set; }
        public bool? IsACSAvialble { get; set; }
        public int? NumberOfObjInACS { get; set; }
        public bool? IsCheckInOutLogAvailable { get; set; }
        public int? NumberOfPointsInLog { get; set; }
        public bool? IsSurveillanceCamerasAvailable { get; set; }
        public int? NumberOfVideoCamsInCentre { get; set; }
        public int? NumberOfStructObjsWithCams { get; set; }
        public int? NumberOfVideoCamsInTerritorialObjs { get; set; }
        public bool? AvailabilityOfSecAlarmsInCentre { get; set; }
        public int? NumberOfRoomsMonitoredByAlarms { get; set; }
        public int? NumberOfTerritObjsWithAlarms { get; set; }
        public bool? IsServerRoomAvailable { get; set; }
        public int? NumberOfServerRoom { get; set; }
        public bool? IsDataCentreAvailable { get; set; }
        public int? NumberOfDataCentre { get; set; }
        public int? NumberOfSRandDCWithMetalDoor { get; set; }
        public int? NumberOfSRandDCWithWithSystemControl { get; set; }
        public bool? IsCoolingSystemAvailable { get; set; }
        public bool? IsAntiFireEquipAvailable { get; set; }
        public bool? IsPlanForPreventiveMaintAvailable { get; set; }
        public bool? AvailabilityOfVideoCamInServerRoom { get; set; }
        public bool? AvailablityOfFalseFloorAndCeiling { get; set; }
        public bool? AvailablityOfTempSensors { get; set; }
        public bool? AvailablityOfLogsForServerRoomEntrance { get; set; }
        public int? NumberOfServersWithSealedOuterCases { get; set; }
        public int? NumberOfWorkStWithSealedOuterCases { get; set; }

        ///<form>2.12</form>
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

        ///<form>2.13</form>
        public bool? IsBackupMeasuresProvided { get; set; }
        public int? NumOfISBackupProvided { get; set; }
        public int? NumOfConfidentialInfo { get; set; }
        public string? BackupFrequency { get; set; }
        public int? NumOfServersSoftRedundancyMeasured { get; set; }
        public bool? IsApprovedScheduleForBackupAvailable { get; set; }

        ///<form>2.14</form>
        public int? NumOfServersWithLicensedOS { get; set; }
        public int? NumOfServersWithUpdatingOs { get; set; }
        public int? NumOfWRoomswihLicensedOS { get; set; }

        ///<form>2.15</form>
        public bool? IsPlannedPrevWorkAvailable { get; set; }
        public string? FrequencyOfPrevMaintanence { get; set; }

        ///<form>2.16</form>
        public bool? IsRecoveryPlansAvailable { get; set; }

        ///<form>2.17</form>
        public bool? AvailabilityOfFireAlarmSystInRoomWithSEq { get; set; }
        public bool? PresenceOfGasFireExtSystInRoomWithSEq { get; set; }
        public bool? AvailablityOfUPSForSEq { get; set; }
        public int? NumberOfServersWithUPS { get; set; }
        public bool? IsUPSAvailableForWRooms { get; set; }
        public int? WorkRoomsWithUPS { get; set; }
        public bool? AvailablityOfAlternativePowerL { get; set; }
        public bool? AvailablityOfGenerators { get; set; }
        public int? NumberOfGenerators { get; set; }

        ///<form>2.18</form>
        public bool? IsLogsOfCarriersOfConfInfAvailable { get; set; }

        ///<form>3.1</form>
        public bool? IsPasswProtectInWRooms { get; set; }
        public int? NumberOfWRoomsWithPasswProtection { get; set; }
        public string? FrequencyOfPasswUpdateInWRooms { get; set; }
        public bool? IsPasswProtectInSRooms { get; set; }
        public int? NumberOfSRoomsWithPasswProtection { get; set; }
        public string? FrequncyOfPasswUpdateInSRooms { get; set; }

        ///<form>3.2</form>
        public bool? IsAccessControlToNetworkInCentreAvailable { get; set; }
        public string? NameOfToolForAccessControlInCentre { get; set; }
        public bool? IsAccessControlToNetworkInStrucDivAvailable { get; set; }
        public int? NumberOfOrgsWithAccesControlToNetwork { get; set; }
        public string? NameOfToolsForAccessControl { get; set; }

        ///<form>3.3</form>
        public bool? IsAccessControlSystemAvailable {get;set;}
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

        ///<form>3.4</form>
        public string? NameAndVersionOfAntimalwareProgram { get; set; }
        public bool? IsLicenseForAntiMAvailable { get; set; }
        public int? NumberOfServersWithAntiM { get; set; }
        public int? NumberOfWRoomsWithAntiM { get; set; }

        ///<form>3.5</form>
        public string? NameAndVersionOfFirewall { get; set; }
        public bool? IsLicenceForFireWallAvailable { get; set; }

        ///<form>3.6</form>
        public string? NameAndVersionOfIDPS { get; set; }
        public bool? IsLicenseForIDPSAvailable { get; set; }

        ///<form>3.7</form>
        public bool? IsEXATAvailable { get; set; }
        public int? NumberOfSystemsWithEXAT { get; set; }

        ///<form>3.8</form>
        public bool? IsHUMOAvailable { get; set; }
        public int? NumberOfsystemsWithHUMO { get; set; }

        ///<form>3.9</form>
        public bool? IsVPNUsed { get; set; }
        public string? PurposeAndScopeOfVPNConnections { get; set; }

        ///<form>3.10</form>
        public string? NameAndVersionOfDLP { get; set; }
        public bool? IsLicenceOfDLPAvaliable { get; set; }
        public int? NumberOfWorkRoomsWithDLP { get; set; }

        ///<form>3.11</form>
        public string? NameAndVersionOfSIEM { get; set; }
        public bool? IsLicenseForSIEMAvailable { get; set; }

        ///<form>3.12</form>
        public string? NameAndVersionOfCAndSAnalysisTool { get; set; }  
        public string? PurposeOfCAndSAnalysisTools { get; set; }
        public string? NumberOfCAndSAnalysisTools { get; set; }

        ///<form>3.13</form>
        public string? NameOfProtectionTool { get; set; }
        public string? PurposeOfProtectionTool { get; set; }
        public int? NumberOfProtectionTool { get; set; }
    }
}
 