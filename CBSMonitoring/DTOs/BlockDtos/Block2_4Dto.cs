using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_4Dto
    {
        [PropertyOrder(1)]
        public bool? IsISecDivisionPresent { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfISEmployees { get; init; }
        [PropertyOrder(3)]
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; init; }
    }
}
