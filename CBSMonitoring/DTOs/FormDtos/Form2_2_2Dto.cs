using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_2_2Dto
    {
        public IEnumerable<TimelyExecutionOfPlanResponse>? ResponseList { get; set; }
        public IEnumerable<int>? FileIds { get; set; }
    }
}
