using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_3_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsAccessControlSystemAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfISWithACS { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfISWithOnlyPassw { get; init; }
        [PropertyOrder(4)]
        public int? NumberOfISWithCryptKeys { get; init; }
        [PropertyOrder(5)]
        public int? NumberOfISWithConfInfUsingACS { get; init; }
        [PropertyOrder(6)]
        public int? NumberOfISWithConfInfWithOnlyPassw { get; init; }
        [PropertyOrder(7)]
        public int? NumberOfISWithConfInfWithCryptKeys { get; init; }
        [PropertyOrder(8)]
        public string? NameOfACMTool { get; init; }
        [PropertyOrder(9)]
        public string? UserIDsInAccess { get; init; }
        [PropertyOrder(10)]
        public bool? IsAccessEventsAndLogsRecorded { get; init; }
        [PropertyOrder(11)]
        public string? FrequencyOfIDsChange { get; init; }
    }
}
