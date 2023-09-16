using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_2_1Dto : BaseFormDto
    {
        #nullable disable
        [PropertyOrder(1)]
        public bool AreInternalRegulationsAvailable { get; init; }
        [PropertyOrder(2)]
        public int NumberOfRegDocs { get; init; }
        [PropertyOrder(3)]
        public string ListOfRegDocs { get; init; }
    }
}
