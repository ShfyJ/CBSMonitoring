using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_18_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsLogsOfCarriersOfConfInfAvailable { get; set; }
    }
}
