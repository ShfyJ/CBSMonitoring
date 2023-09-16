using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_5Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool IsAuditConducted { get; init; }
    }
}
