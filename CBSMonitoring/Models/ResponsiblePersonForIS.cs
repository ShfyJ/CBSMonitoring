namespace CBSMonitoring.Models
{
    public class ResponsiblePersonForIS : OrgMonitoring //2.5
    {
        public bool? IsResponsiblePersonAssigned { get; set; }
        public string? FullNameOfRespPerSon { get; set; }
        public string? PositionOfRespPerson { get; set; }
        public string? TelNumOfRespPerson { get; set; }
        public string? EmailOfRespPerson { get; set; }
    }
}
