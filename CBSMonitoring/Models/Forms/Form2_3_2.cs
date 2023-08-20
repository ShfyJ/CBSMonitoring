using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form2_3_2 : OrgMonitoring
    {
        public bool? IsObjectsClasified { get; set; }
        public int? File_2_3_2Id { get; set; }
        [ForeignKey(nameof(File_2_3_2Id))]
        public FileModel? FileModel { get; set; }
    }
}
