using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_2Dto
    {
        [PropertyOrder(1)]
        public int NumberOfSectsInActionPlan { get; init; }
        [PropertyOrder(2)]
        public int NumberOfDoneSects { get; init; }
        [PropertyOrder(3)]
        public int NumberOfDoneSectsInTime { get; init; }
    }
}
