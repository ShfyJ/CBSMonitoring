using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block1_1Dto
    {
        [PropertyOrder(1)]
        public bool HasPolicy { get; init; }
        [PropertyOrder(2)]
        public bool IsReviewedByCBS { get; init; }
        [PropertyOrder(3)]
        public bool AgreedWithAuthBody { get; init; }
        [PropertyOrder(4)]
        public bool AreEmpsFamiliarWithISP { get; init; }
        //[PropertyOrder(5)]
        //public int NumberOfEmployees { get; init; }
        [PropertyOrder(5)]
        public float PercentageOfEmpFamiliarWithPolicy { get; init; }
        [PropertyOrder(6)]
        public bool IsAuditConducted { get; init; }
        [PropertyOrder(7)]
        public bool HasISPRevised { get; init; }
        [PropertyOrder(8)]
        public int NumberOfRevision { get; init; }
        //[PropertyOrder(10)]
        //public int YearOfRevisions { get; init; }
    }
}
