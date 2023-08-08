using System.Reflection.Emit;

namespace CBSMonitoring.Models
{
    public class RegulationsOnConfidentiality : OrgMonitoring //1.5
    {
        public bool? IsAgreementsAvailable { get; set; }
        public bool? IsRelevantClausesAvailable { get;set; }
        public int? NumberOfEmplFamWithAgreements { get; set; }
        public float? PercentageOfEmpFamWithAgreements { get;set; }

    }
}
