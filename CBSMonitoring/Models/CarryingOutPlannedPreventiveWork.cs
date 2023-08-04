namespace CBSMonitoring.Models
{
    public class CarryingOutPlannedPreventiveWork : OrgMonitoring //2.15
    {
        public bool? IsPlannedPrevWorkAvailable { get; set; }
        public string? FrequencyOfPrevMaintanence {get;set;}
    }
}
