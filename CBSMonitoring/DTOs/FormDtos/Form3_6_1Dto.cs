namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_6_1Dto : BaseFormDto
    {
        public bool? IsIDPSAvailable { get; init; }
        public string? NameAndVersionOfIDPS { get; init; }
        public string? IDPSType { get; init; }
        public bool? IsLicenseForIDPSAvailable { get; init; }
    }
}
