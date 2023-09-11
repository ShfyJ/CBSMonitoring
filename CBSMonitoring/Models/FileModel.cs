using CBSMonitoring.Models.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class FileModel
    {
        [Key]
        public int FileId { get; set; }
        #nullable disable
        public string Name { get; set; }
        public string Description { get; set; }
        //public int FileInfoType { get; set; }    //What the file is about
        public string Extension { get; set; }
        public string FilePath { get; set; }
        public string SystemPath { get; set; }
        public string BasePath { get; set; }
        public string ContentType { get; set; }
        #nullable enable
        public int? Form2_2_2Id { get; set; }
        [ForeignKey(nameof(Form2_2_2Id))]
        public Form2_2_2? Form2_2_2 { get; set; }
        public string? DocNumber { get; set; }
        public DateTime? DocDate { get; set; }
        #nullable disable
    }
}
