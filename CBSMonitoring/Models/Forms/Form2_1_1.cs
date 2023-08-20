using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form2_1_1 : OrgMonitoring //2.1
    {
        public bool? IsActionPlanAvailableToEnsIC { get; set; }
        public int? File_2_1_1Id { get; set; }
        [ForeignKey(nameof(File_2_1_1Id))]
        public FileModel? FileModel { get; set; }
        public string? ReasonForAbsenceOfPlan { get; set; }

    }
}
