using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_11_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsEntranceSecurityAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfObjWithSecurity { get; init; }
    }
}
