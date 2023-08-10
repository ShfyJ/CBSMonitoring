namespace CBSMonitoring.Models
{
    public class Form2_2 : OrgMonitoring //2.2
    {
        public int? SectNumber { get; set; }
        public DateTime? DeadlineOfPlan { get; set; }
        public bool? IsExecuted { get; set; }
        public bool? DeadlineOfRealExec { get; set; }
        public ICollection<FileModel>? Files { get; set; }
    }
}
