using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models.Forms
{
    public class Form1_1_1 : OrgMonitoring   //1.1
    {
        [Required(ErrorMessage = "Это поле обязательно")]
        public bool? HasPolicy { get; set; }
        public int? File_1_1_1Id { get; set; }
        [ForeignKey(nameof(File_1_1_1Id))]
        public FileModel? FileModel { get; set; }

        #region additional properties
        //public string? Form1_1_1Input1 { get; set; }
        //public string? Form1_1_1Input2 { get; set; }
        #endregion
    }
}
