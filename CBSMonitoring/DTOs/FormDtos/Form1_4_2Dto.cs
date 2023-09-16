using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_4_2Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public bool IsComissionPresent { get; init; }
        [PropertyOrder(2)]
        public string ComissionDocNumber { get; init; }
        [PropertyOrder(3)]
        public DateTime ComissionDocDate { get; init; }
    }
}
