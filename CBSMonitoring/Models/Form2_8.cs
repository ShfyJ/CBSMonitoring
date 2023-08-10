namespace CBSMonitoring.Models
{
    public class Form2_8 : OrgMonitoring //2.8
    {
        public int? NumberOfEmpsQualificaitonImproved { get; set; }
        public int[]? QualifImpEmpIds { get; set; }
        public ICollection<QualificationImprovedEmployee>? QualificationImprovedEmployees { get; set; }
    }
}
