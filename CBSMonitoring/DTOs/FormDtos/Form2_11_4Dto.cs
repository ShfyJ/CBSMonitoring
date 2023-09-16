using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_11_4Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsSurveillanceCamerasAvailable { get; init; }
        [PropertyOrder(2)]
        public int? NumberOfVideoCamsInCentre { get; init; }
        [PropertyOrder(3)]
        public int? NumberOfStructObjsWithCams { get; init; }
        [PropertyOrder(4)]
        public int? NumberOfVideoCamsInTerritorialObjs { get; init; }
    }
}
