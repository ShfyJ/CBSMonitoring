using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_17_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool? IsFireAlarmSystAvailable { get; init; }
        [PropertyOrder(2)]
        public bool? IsGasFireExtSystAvailable { get; init; }
        [PropertyOrder(3)]
        public bool? IsUPSForSEqAvailable { get; init; }
        [PropertyOrder(4)]
        public int? NumberOfServersWithUPS { get; init; }
        [PropertyOrder(5)]
        public bool? IsUPSAvailableForWRs { get; init; }
        [PropertyOrder(6)]
        public int? NumberOfWRsWithUPS { get; init; }
        [PropertyOrder(7)]
        public bool? IsAlternativePowerLAvailable { get; init; }
        [PropertyOrder(8)]
        public bool? IsGeneratorsAvailable { get; init; }
        [PropertyOrder(9)]
        public int? NumberOfGenerators { get; init; }
    }
}
