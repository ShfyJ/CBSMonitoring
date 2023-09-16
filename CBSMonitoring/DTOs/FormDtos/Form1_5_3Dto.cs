using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_5_3Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsEmployeesFamWithAgreements { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfEmplFamWithAgreements { get; init; }
        [PropertyOrder(3)]
        public float? PercentageOfEmpFamWithAgreements { get; init; }
    }
}
