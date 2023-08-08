namespace CBSMonitoring.Models
{
    public class ImprovingEmployeeQualification : OrgMonitoring //2.8
    {
        public int? NumberOfEmpsQualificaitonImproved { get; set; }
        public int[]? QualifImpEmpIds { get; set; }
        public ICollection<QualificationImprovedEmployee>? QualificationImprovedEmployees { get; set; }
    }
}
