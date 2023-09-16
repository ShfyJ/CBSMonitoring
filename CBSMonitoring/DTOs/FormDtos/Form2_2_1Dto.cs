using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_2_1Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public int NumberOfSectsInActionPlan { get; init; }
        [PropertyOrder(2)]
        public int NumberOfDoneSects { get; init; }
        [PropertyOrder(3)]
        public int NumberOfDoneSectsInTime { get; init; }
        [PropertyOrder(4)]
        public int FileId { get; init; }
    }
}
