using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_4Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public bool AreEmpsFamiliarWithISP { get; init; }
        [PropertyOrder(2)]
        public int NumberOfEmployees { get; init; }
        [PropertyOrder(3)]
        public float PercentageOfEmpFamiliarWithPolicy { get; init; }

    }
}
