using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_11_7Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsSealedOuterCaseAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfServersWithSealedOuterCases { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfWStWithSealedOuterCases { get; init; }
    }
}
