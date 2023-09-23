using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_13Dto
    {
        [PropertyOrder(1)]
        public bool? IsBackupMeasuresProvided { get; init; }
        [PropertyOrder(2)]
        public int? NumOfISBackupProvided { get; init; }
        [PropertyOrder(3)]
        public int? NumOfConfidentialInfo { get; init; }
        [PropertyOrder(4)]
        public int? NumOfServersSoftRedundancyMeasured { get; init; }
        [PropertyOrder(5)]
        public bool? IsApprovedScheduleForBackupAvailable { get; init; }
    }
}
