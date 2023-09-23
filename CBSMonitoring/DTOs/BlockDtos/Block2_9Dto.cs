using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_9Dto
    {
        [PropertyOrder(1)]
        public string? WebAddress { get; init; }
        [PropertyOrder(2)]
        public string? ExpertizingPeriod { get; init; }
        [PropertyOrder(3)]
        public bool? HasShortcomings { get; init; }
        [PropertyOrder(4)]
        public bool? IsShortcomingsOfWebsiteEliminated { get; init; }
    }
}
