using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_4_1Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public bool IsListOfConfInfoAvailable { get; init; }
        [PropertyOrder(2)]
        public string ConfidentialDocNumber { get; init; }
        [PropertyOrder(3)]
        public DateTime ConfidentialDocDate { get; init; }

    }
}
