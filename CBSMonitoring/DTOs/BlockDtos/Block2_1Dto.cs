using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_1Dto
    {
        [PropertyOrder(1)]
        public bool? IsActionPlanAvailableToEnsIC { get; set; }
        [PropertyOrder(2)]
        public bool? IsActionPlanAgreedToEnsIC { get; set; }

    }
}
