using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_11_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsSIEMAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NameAndVersionOfSIEM { get; init; }
        [PropertyOrder(3)]
        public bool? IsLicenseForSIEMAvailable { get; init; }
    }
}
