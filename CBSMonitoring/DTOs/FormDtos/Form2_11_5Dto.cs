using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_11_5Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsSecAlarmsInCentreAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfRoomsMonitoredByAlarms { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfTerritObjsWithAlarms { get; init; }
    }
}
