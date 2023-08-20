using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form1_1_2 : OrgMonitoring
    {
        public bool? IsReviewedByCBS { get; set; }
        public int? File_1_1_2Id { get; set; }
        [ForeignKey(nameof(File_1_1_2Id))]
        public FileModel? FileModel { get; set; }
    }
}
