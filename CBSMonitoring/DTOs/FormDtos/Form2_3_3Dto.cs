using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_3_3Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsISystemAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NamesOfISystems { get; init; }
    }
}
