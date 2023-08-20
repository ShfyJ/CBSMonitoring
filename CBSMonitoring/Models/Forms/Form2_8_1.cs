namespace CBSMonitoring.Models.Forms
{
    public class Form2_8_1 : OrgMonitoring //2.8
    {
        public bool? IsEmpsQualificationImproved { get; set; }
        public int? NumberOfEmpsQualificaitonImproved { get; set; }
        public int[]? QualifImpEmpIds { get; set; }
        public ICollection<QualificationImprovedEmployee>? QualificationImprovedEmployees { get; set; }
    }
}
