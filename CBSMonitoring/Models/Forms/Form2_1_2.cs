using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form2_1_2 : OrgMonitoring
    {
        public bool? IsActionPlanAgreedToEnsIC { get; set; }
        public int? File_2_1_2Id { get; set; }
        [ForeignKey(nameof(File_2_1_2Id))]
        public FileModel? FileModel { get; set; }
        public string? ReasonForAbsenceOfAgreement { get; set; }
    }
}
