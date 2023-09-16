using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_1Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public bool HasPolicy { get; init; }
        #nullable enable
        [PropertyOrder(2)]
        public int? FileId { get; init; }

    }

}
