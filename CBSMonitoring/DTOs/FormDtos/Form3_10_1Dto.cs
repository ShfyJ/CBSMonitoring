using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form3_10_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsDLPAvailable { get; init; }
        [PropertyOrder(2)]
        public string? NameAndVersionOfDLP { get; init; }
        [PropertyOrder(3)]
        public bool? IsLicenceOfDLPAvaliable { get; init; }
        [PropertyOrder(4)]
        public int? NumberOfWorkRoomsWithDLP { get; init; }
    }
}
