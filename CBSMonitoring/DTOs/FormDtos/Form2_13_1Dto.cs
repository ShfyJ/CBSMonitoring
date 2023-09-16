using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_13_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsBackupMeasuresProvided { get; init; }
        [PropertyOrder(2)]
        public int? NumOfISBackupProvided { get; init; }
        [PropertyOrder(3)]
        public int? NumOfConfidentialInfo { get; init; }
        [PropertyOrder(4)]
        public string? BackupFrequency { get; init; }
        [PropertyOrder(5)]
        public int? NumOfServersSoftRedundancyMeasured { get; init; }
        [PropertyOrder(6)]
        public bool? IsApprovedScheduleForBackupAvailable { get; init; }
    }
}
