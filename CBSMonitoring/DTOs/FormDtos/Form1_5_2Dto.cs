using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_5_2Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsRelevantClausesAvailable { get; init; }
    }
}
