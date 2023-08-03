namespace CBSMonitoring.Models
{
    public class TimelyExecutionOfPlanSection : OrgMonitoring //2.2
    {
        public int SectNumber { get; set; }
        public DateTime DeadlineOfPlan { get; set; }
        public bool IsExecuted { get; set; }
        public bool DeadlineOfRealExec { get; set; }
        #nullable disable
        public ICollection<FileModel> Files { get; set; }
    }
}
