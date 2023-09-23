using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block2_12Dto
    {
        [PropertyOrder(1)]
        public bool? IsLogsForIncidentsAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfObjWithIncidentLog { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfIncidents { get; init; }
        [PropertyOrder(4)]
        public int? NumOfIncidentsInStructOrg { get; init; }
        [PropertyOrder(5)]
        public int? NumOfIncidentsInSubObjects { get; init; }
        [PropertyOrder(6)]
        public int? NumOfIncidentsInvestigated { get; init; }
        [PropertyOrder(7)]
        public int? NumOFIncidentsResoluted { get; init; }
    }
}
