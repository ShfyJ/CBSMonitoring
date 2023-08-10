namespace CBSMonitoring.Models
{
    public class Form2_12 : OrgMonitoring //2.12
    {
        public bool? IsLogsForIncidentsAvailable { get; set; } 
        public int? NumberOfObjWithIncidentLog { get; set; }     
        public bool? IsDepISAndHeadNotified { get; set; }
        public bool? IsIncidentsInvestigated { get; set; }
        public bool? IsAnyIncidentResoluted { get; set; }
        public int? NumberOfIncidents { get; set; }
        public int? NumOfIncidentsInStructOrg { get; set; }
        public int? NumOfIncidentsInSubObjects { get; set; }
        public int? NumOfIncidentsInvestigated { get; set; }
        public int? NumOFIncidentsResoluted { get; set; }

    }
}
