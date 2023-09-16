using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_5_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsResponsiblePersonForISAssigned { get; init; }
        [PropertyOrder(2)]
        public string? FullNameOfRespPerSon { get; init; }
        [PropertyOrder(3)]
        public string? PositionOfRespPerson { get; init; }
        [PropertyOrder(4)]
        public string? TelNumOfRespPerson { get; init; }
        [PropertyOrder(5)]
        public string? EmailOfRespPerson { get; init; }
    }
}
