﻿namespace CBSMonitoring.Models
{
    public class IRDocumentsNumAndList : OrgMonitoring  //1.2
    {
        public int NumberOfRegDocs { get; set; }
        #nullable disable
        public string ListOfRegDocs { get; set; }
    }
}
