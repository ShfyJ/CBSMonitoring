using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form1_1_1 : OrgMonitoring   //1.1
    {
        public bool? HasPolicy { get; set; }
        public int? File_1_1_1Id { get; set; }
        [ForeignKey(nameof(File_1_1_1Id))]
        public FileModel? FileModel { get; set; }
    }
}
