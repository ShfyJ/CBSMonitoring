using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_2Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public bool IsReviewedByCBS { get; init; }
        #nullable enable
        [PropertyOrder(2)]
        public int? FileId { get; init; }
    }
}
