using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_2_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsACToNetInCentreAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NameOfToolForACInCentre { get; init; }
    }
}
