using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_14_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsSystemUpdateHold { get; init; }
        [PropertyOrder(2)]
        public int? NumOfServersWithLicensedOS { get; init; }
        [PropertyOrder(3)]
        public int? NumOfServersWithUpdatingOs { get; init; }
        [PropertyOrder(4)]
        public int? NumOfWRoomswihLicensedOS { get; init; }
    }
}
