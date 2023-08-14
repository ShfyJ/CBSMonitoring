namespace CBSMonitoring.Models
{
    public class Form1_1 : OrgMonitoring   //1.1
    {
        public bool? HasPolicy { get; set; }
        public bool? IsReviewedByCBS { get; set; }
        public bool? AgreedWithAuthBody { get; set; }
        public int? NumberOfEmployees { get; set; }
        public float? PercentageOfEmpFamiliarWithPolicy { get; set; }
        public bool? IsAuditConducted { get; set; }
        public bool? HasISPRevised { get; set; }
        public int? NumberOfRevision { get; set; }
        public int? YearOfRevisions { get; set; }
        public ICollection<FileModel>? Files { get; set; }
    }
}
