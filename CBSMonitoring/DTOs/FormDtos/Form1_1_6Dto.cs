using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.FormDtos
{
    public class Form1_1_6Dto : BaseFormDto
    {
        [PropertyOrder(1)]
        public bool HasISPRevised { get; init; }
        [PropertyOrder(2)]
        public int NumberOfRevision { get; init; }
        [PropertyOrder(3)]
        public int YearOfRevisions { get; init; }
    }
}
