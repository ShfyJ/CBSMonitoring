using CBSMonitoring.Models.Forms;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_1Dto 
    {
        public int OrganizationId { get; set; }
        public int QuaterIndex { get; set; }
        public int Year { get; set; }
        public List<FileItem>? Files { get; set; }
        public int? FileId { get; set; }
        public string? SectionNumber { get; set; }
        public bool? HasPolicy { get; set; }
    }

}
