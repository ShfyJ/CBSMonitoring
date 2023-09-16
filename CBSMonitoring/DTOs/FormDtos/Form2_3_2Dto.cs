using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_3_2Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool IsObjectsClassified { get; init; }
        [PropertyOrder(2)]
        public int FileId { get; init; }
    }
}
