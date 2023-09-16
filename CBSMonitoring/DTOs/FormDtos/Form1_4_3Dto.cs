using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_4_3Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsListOfOfficialAvailable { get; init; }
        [PropertyOrder(2)]
        public string? OfficialsDocNumber { get; init; }
        [PropertyOrder(3)]
        public DateTime? OfficialsDocDate { get; init; }
    }
}
