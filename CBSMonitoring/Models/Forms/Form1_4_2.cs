namespace CBSMonitoring.Models.Forms
{
    public class Form1_4_2 : OrgMonitoring
    {
        public bool? IsComissionPresent { get; set; }
        //public string? WhyNotComission { get; set; }
        public string? ComissionDocNumber { get; set; }
        public DateTime? ComissionDocDate { get; set; }
    }
}
