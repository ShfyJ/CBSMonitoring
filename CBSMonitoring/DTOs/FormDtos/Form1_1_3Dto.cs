﻿namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_3Dto
    {
        #nullable disable
        public string OrganizationName { get; set; }
        public int QuarterIndex { get; set; }
        public int Year { get; set; }
        public string SectionNumber { get; set; }
        public bool AgreedWithAuthBody { get; set; }
        public string FileDescription { get; set; } = "Файл";
        #nullable enable
        public int? FileId { get; set; }
    }
}
