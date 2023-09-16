using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_3_1Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public bool IsListOfProtectedObjAvailable { get; init; }
        [PropertyOrder(2)]
        public int FileId { get; init; }
    }
}
