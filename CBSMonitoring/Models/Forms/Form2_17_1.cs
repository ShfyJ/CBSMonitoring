namespace CBSMonitoring.Models.Forms
{
    public class Form2_17_1 : OrgMonitoring //2.17
    {
        public bool? IsFireAlarmSystAvailable { get; set; }
        public bool? IsGasFireExtSystAvailable { get; set; }
        public bool? IsUPSForSEqAvailable { get; set; }
        public int? NumberOfServersWithUPS { get; set; }
        public bool? IsUPSAvailableForWRs { get; set; }
        public int? NumberOfWRsWithUPS { get; set; }
        public bool? IsAlternativePowerLAvailable { get; set; }
        public bool? IsGeneratorsAvailable { get; set; }
        public int? NumberOfGenerators { get; set; }
    }
}
