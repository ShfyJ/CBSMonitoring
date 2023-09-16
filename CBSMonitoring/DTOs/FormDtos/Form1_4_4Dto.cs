using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_4_4Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsListOfConfInfoProvidedToEmps { get; init; }
    }
}
