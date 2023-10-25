using CBSMonitoring.Models;
using CBSMonitoring.Webframework;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_8_1Dto : BaseFormDto
    {
        [PropertyDisplay(true)]
        [PropertyOrder(1)]
        public bool IsEmpsQualificationImproved { get; init; }

        [PropertyDisplay(true)]
        [PropertyOrder(2)]
        public int NumberOfEmpsQualificaitonImproved { get; init; }

        [PropertyDisplay(true)]
        [PropertyOrder(3)]
        public IEnumerable<QualificationImprovedEmployeeResponse>? QualificationImprovedEmployees { get; init; }
    }
}
