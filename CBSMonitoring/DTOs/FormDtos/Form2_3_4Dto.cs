using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_3_4Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; init; }
        [PropertyOrder(2)]
        public string? NameOfOutSourcingOrg { get; init; }
        [PropertyOrder(3)]
        public string? ContractNumberOfOutsoucingOrg { get; init; }
        [PropertyOrder(4)]
        public DateTime? ContractDateOfOutsoucingOrg { get; init; }
        [PropertyOrder(5)]
        public string? ListOfServicesOfOutsourcingOrg { get; init; }
    }
}
