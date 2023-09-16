using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_12_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsLogsForIncidentsAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfObjWithIncidentLog { get; init; }
        [PropertyOrder(3)]
        public bool? IsDepISAndHeadNotified { get; init; }
        [PropertyOrder(4)]
        public bool? IsIncidentsInvestigated { get; init; }
        [PropertyOrder(5)]
        public bool? IsAnyIncidentResoluted { get; init; }
        [PropertyOrder(6)]
        public int? NumberOfIncidents { get; init; }
        [PropertyOrder(7)]
        public int? NumOfIncidentsInStructOrg { get; init; }
        [PropertyOrder(8)]    
        public int? NumOfIncidentsInSubObjects { get; init; }
        [PropertyOrder(9)]
        public int? NumOfIncidentsInvestigated { get; init; }
        [PropertyOrder(10)]
        public int? NumOFIncidentsResoluted { get; init; }
    }
}
