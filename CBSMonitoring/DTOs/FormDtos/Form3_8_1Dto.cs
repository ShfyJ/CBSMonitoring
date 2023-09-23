using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_8_1Dto : BaseFormDto 
    {
        [PropertyOrder(1)]
        public bool? IsHUMOAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfsystemsWithHUMO { get; init; }
    }
}
