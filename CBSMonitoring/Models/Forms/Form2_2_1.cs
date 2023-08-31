using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form2_2_1 : OrgMonitoring //2.2
    {
        public int? NumberOfSectsInActionPlan { get; set; }
        public int? NumberOfDoneSects { get; set; }
        public int? NumberOfDoneSectsInTime { get; set; }
        public int? File_2_2_1Id { get; set; }
        [ForeignKey(nameof(File_2_2_1Id))]
        public FileModel? FileModel { get; set; }
    }
}
