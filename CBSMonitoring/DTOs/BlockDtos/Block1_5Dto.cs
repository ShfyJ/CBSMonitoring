using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block1_5Dto
    {
        [PropertyOrder(1)]
        public bool? IsAgreementOnPrivacyAvailable { get; init; }
        [PropertyOrder(2)]
        public bool? IsRelevantClausesAvailable { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfEmplFamWithAgreements { get; init; }
        [PropertyOrder(4)]
        public float? PercentageOfEmpFamWithAgreements { get; init; }
    }
}
