﻿namespace CBSMonitoring.Models
{
    public class AvailablityOfOtherMeansOfProtection: OrgMonitoring //3.13
    {
        public string? NameOfProtectionTool { get; set; }
        public string? PurposeOfProtectionTool { get; set; }
        public int? NumberOfProtectionTool {get;set; }

    }
}
