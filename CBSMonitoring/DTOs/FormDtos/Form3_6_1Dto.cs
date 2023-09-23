using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_6_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsIDPSAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NameAndVersionOfIDPS { get; init; }
        [PropertyOrder(3)]
        public string? IDPSType { get; init; }
        [PropertyOrder(4)]
        public bool? IsLicenseForIDPSAvailable { get; init; }
    }
}
