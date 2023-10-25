using CBSMonitoring.Webframework;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_2_2Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public ICollection<TimelyExecutionOfPlanResponse>? ResponseList { get; init; }

        [PropertyOrder(2)]
        public ICollection<int>? FileIds { get; set; }
    }
}
