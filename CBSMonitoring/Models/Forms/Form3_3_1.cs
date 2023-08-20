namespace CBSMonitoring.Models.Forms
{
    public class Form3_3_1 : OrgMonitoring //3.3
    {
        public bool? IsAccessControlSystemAvailable { get; set; }
        public int? NumberOfISWithACS { get; set; }
        public int? NumberOfISWithOnlyPassw { get; set; }
        public int? NumberOfISWithCryptKeys { get; set; }
        public int? NumberOfISWithConfInfUsingACS { get; set; }
        public int? NumberOfISWithConfInfWithOnlyPassw { get; set; }
        public int? NumberOfISWithConfInfWithCryptKeys { get; set; }
        public string? NameOfACMTool { get; set; }
        public string? UserIDsInAccess { get; set; }
        public bool? IsAccessEventsAndLogsRecorded { get; set; }
        public string? FrequencyOfIDsChange { get; set; }


    }
}
