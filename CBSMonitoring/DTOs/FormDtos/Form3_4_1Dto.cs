using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_4_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsAnitivirusAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NameAndVersionOfAntivirus { get; init; }
        [PropertyOrder(3)]
        public bool? IsLicenseForAntivirusAvailable { get; init; }
        [PropertyOrder(4)]
        public int? NumberOfServersWithAntivirus { get; init; }
        [PropertyOrder(5)]
        public int? NumberOfWRsWithAntivirus { get; init; }
    }
}
