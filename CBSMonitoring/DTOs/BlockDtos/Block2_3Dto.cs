using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_3Dto
    {
        [PropertyOrder(1)]
        public bool? IsListOfProtectedObjAvailable { get; init; }
        [PropertyOrder(2)]
        public bool? IsObjectsClassified { get; init; }
        [PropertyOrder(3)]
        public bool? IsISystemAvailable { get; init; }
        [PropertyOrder(1)]
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; init; }
    }
}
