namespace CBSMonitoring.Models
{
    public class Form2_4 : OrgMonitoring //2.4
    {
        public bool? IsISecDivisionPresent { get; set; }
        public string? ISsecDivisionName { get; set; }
        public bool? IsDevisionPositionPresent { get; set; }
        public string? SectionHeadFullName { get; set; }
        public string? PositionOfSectionHead { get; set; }
        public string? PhoneNumOfSectionHead { get;set; }
        public string? EmailOfSectionHead { get; set; }
        public int? NumberOfISEmployees { get; set; }
        public bool? IsOrganizationInvolvedInOutsourcingOfIS { get; set; }
        public string? NameOfOutSourcingOrg { get;set; }
        public string? ContractNumberOfOutsoucingOrg { get; set; }
        public DateTime? ContractDateOfOutsoucingOrg { get; set; }
        public string? ListOfServicesOfOutsourcingOrg { get; set; }
        public ICollection<FileModel>? Files { get; set; }

    }
}
