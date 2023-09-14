using CBSMonitoring.Models;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form2_8_1Dto : BaseFormDto
    {
        public bool IsEmpsQualificationImproved { get; init; }
        public int NumberOfEmpsQualificaitonImproved { get; init; }
        public IEnumerable<QualificationImprovedEmployeeResponse>? QualificationImprovedEmployees { get; init; }
    }
}
