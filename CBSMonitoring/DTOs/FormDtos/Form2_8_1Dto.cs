using CBSMonitoring.Models;
using CBSMonitoring.Webframework;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_8_1Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool IsEmpsQualificationImproved { get; init; }
        [PropertyOrder(2)]
        public int NumberOfEmpsQualificaitonImproved { get; init; }
        [PropertyOrder(3)]
        public IEnumerable<QualificationImprovedEmployeeResponse>? QualificationImprovedEmployees { get; init; }
    }
}
