namespace CBSMonitoring.Models
{
    public class Form1_4 : OrgMonitoring  //1.4
    {
        public bool? IsListAvailable { get; set; }
        public string? ConfidentialDocNumber { get; set; }
        public DateTime? ConfidentialDocDate { get;set; }
        public bool? IsComissionPresent { get; set; }
        public string? ComissionDocNumber { get; set; }
        public DateTime? ComissionDocDate { get; set; }
        public bool? IsListOfOfficialAvailable { get; set; }
        public string? OfficialsDocNumber { get; set; }
        public DateTime? OfficialsDocDate { get; set; }
        public bool? IsListCommToEmps { get; set; }
    }
}
