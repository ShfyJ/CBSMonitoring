using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_3_1Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public bool AreRegsAndRecordsAvailable { get; init; }
        [PropertyOrder(2)]
        public int NumberOfRegAndRecords { get; init; }
        [PropertyOrder(3)]
        public string ListOfRegAndRecords { get; init; }
    }
}
