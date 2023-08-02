﻿using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.Models
{
    public class FileModel
    {
        [Key]
        public int FileId { get; set; }
        #nullable disable
        public string Name { get; set; }
        public int FileInfoType { get; set; }    //What the file is about
        public string Extension { get; set; }
        public string FilePath { get; set; }
        public string SystemPath { get; set; }
        public string BasePath { get; set; }
        #nullable enable
        public string? DocNumber { get; set; }
        public DateTime? DocDate { get; set; }
        #nullable disable
    }
}
