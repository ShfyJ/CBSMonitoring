using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_11_3Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsCheckInOutLogAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfPointsInLog { get; init; }
    }
}
