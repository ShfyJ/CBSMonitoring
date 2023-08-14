using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CBSMonitoring.DTOs
{
    public class MonitoringFormDTO
    {
        public int? Id { get; set; }
        public List<int>? ItemIds { get; set; }
        #nullable disable
        public string FormNumber { get; set; }
        public bool IsActive { get; set; }
        
    }
}
