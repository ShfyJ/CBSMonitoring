using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_2_2Dto : BaseFormDto
    {
        public IEnumerable<TimelyExecutionOfPlanResponse>? ResponseList { get; init; }
        public IEnumerable<int>? FileIds { get; set; }
    }
}
