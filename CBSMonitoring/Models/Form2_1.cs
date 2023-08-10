namespace CBSMonitoring.Models
{
    public class Form2_1 : OrgMonitoring //2.1
    {
        public bool? IsActionPlanAvailableToEnsIC { get; set; }
        public string? ReasonForAbsenceOfPlan { get; set; }
        public bool? IsActionPlanAgreedToEnsIC {get;set;}
        public string? ReasonForAbsenceOfAgreement { get; set; }
        public ICollection<FileModel>? Files { get; set; }
    }
}
