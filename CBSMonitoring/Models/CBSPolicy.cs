namespace CBSMonitoring.Models
{
    public class CBSPolicy : OrgMonitoring   //1.1
    {
        public bool HasPolicy { get; set; }
        public bool IsReviewedByCBS { get; set; }
        public int NumberOfEmployees { get; set; }
        public float PercentageOfEmpFamiliarWithPolicy { get; set; }
        public bool IsAuditConducted { get; set; }
        public bool HasISPRevised { get; set; }
        public int NumberOfRevision { get; set; }
        public int YearOfRevisions { get; set; }
        #nullable disable
        public ICollection<FileModel> Files { get; set; }
    }
}
