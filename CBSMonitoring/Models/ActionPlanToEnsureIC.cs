namespace CBSMonitoring.Models
{
    public class ActionPlanToEnsureIC : OrgMonitoring //2.1
    {
        public bool IsActionPlanAvailableToEnsIC { get; set; }
        public string? ReasonForAbsenceOfPlan { get; set; }
        public bool IsActionPlanAgreedToEnsIC {get;set;}
        public string? ReasonForAbsenceOfAgreement { get; set; }
        #nullable disable
        public ICollection<FileModel> Files { get; set; }
    }
}
