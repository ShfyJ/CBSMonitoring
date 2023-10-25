using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block1_4Dto
    {
        [PropertyOrder(1)]
        public bool? IsListOfConfInfoAvailable { get; init; }
        //[PropertyOrder(2)]
        //public bool IsListIntroducedByOrder { get; init; }   //if order file exists
        [PropertyOrder(3)]
        public bool? IsComissionPresent { get; init; }
        [PropertyOrder(3)]
        public bool? IsListOfOfficialAvailable { get; init; }
        [PropertyOrder(4)]
        public bool? IsListOfConfInfoProvidedToEmps { get; init; }
    }
}
