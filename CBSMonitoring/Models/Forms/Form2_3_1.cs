using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form2_3_1 : OrgMonitoring      //2.3
    {
        public bool? IsListOfProtectedObjAvailable { get; set; }
        public int? File_2_3_1Id { get; set; }
        [ForeignKey(nameof(File_2_3_1Id))]
        public FileModel? FileModel { get; set; }

    }
}
