using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_17Dto
    {
        
        [PropertyOrder(1)]
        public int? NumberOfServersWithUPS { get; init; }
        
        [PropertyOrder(2)]
        public int? NumberOfWRsWithUPS { get; init; }

        [PropertyOrder(3)]
        public int? NumberOfGenerators { get; init; }
    }
}
