namespace CBSMonitoring.Models
{
    public class ImpOfInformationBackup : OrgMonitoring //2.13
    {
        public bool? IsBackupMeasuresProvided { get; set; }
        public int? NumOfISBackupProvided { get; set; }
        public int? NumOfConfidentialInfo { get; set; }
        public string? BackupFrequency { get; set; }    
        public int? NumOfServersSoftRedundancyMeasured { get; set; }
        public bool? IsApprovedScheduleForBackupAvailable { get; set; }
    }
}
