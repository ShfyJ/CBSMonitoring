using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_2_2Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsACToNetInStrucDivAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumOfOrgsWithACToNetInStrucDiv { get; init; }
        [PropertyOrder(3)]
        public string? NameOfToolsForACInStrucDiv { get; init; }
    }
}
