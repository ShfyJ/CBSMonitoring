using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_11_2Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsACSAvialble { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfObjInACS { get; init; }
    }
}
