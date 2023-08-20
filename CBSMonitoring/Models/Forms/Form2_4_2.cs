namespace CBSMonitoring.Models.Forms
{
    public class Form2_4_2 : OrgMonitoring
    {
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; set; }
        public string? NameOfOutSourcingOrg { get; set; }
        public string? ContractNumberOfOutsoucingOrg { get; set; }
        public DateTime? ContractDateOfOutsoucingOrg { get; set; }
        public string? ListOfServicesOfOutsourcingOrg { get; set; }
    }
}
