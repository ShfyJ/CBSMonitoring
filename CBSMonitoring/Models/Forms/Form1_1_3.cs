using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form1_1_3 : OrgMonitoring
    {
        public bool? AgreedWithAuthBody { get; set; }
        public int? File_1_1_3Id { get; set; }
        [ForeignKey(nameof(File_1_1_3Id))]
        public FileModel? FileModel { get; set; }
    }
}
