using CBSMonitoring.Webframework;

namespace CBSMonitoring.DTOs.BlockDtos
{
    public class Block1_1Dto
    {
        [PropertyDisplay(true)][PropertyOrder(1)] public bool? HasPolicy { get; init; } 

        [PropertyDisplay(true)][PropertyOrder(2)] public bool? IsReviewedByCBS { get; init; } 

        [PropertyDisplay(true)][PropertyOrder(3)] public bool? AgreedWithAuthBody { get; init; } 

        [PropertyDisplay(true)][PropertyOrder(4)] public bool? AreEmpsFamiliarWithISP { get; init; } 
        //[PropertyOrder(5)]
        //public int NumberOfEmployees { get; init; }

        [PropertyDisplay(true)][PropertyOrder(5)] public float? PercentageOfEmpFamiliarWithPolicy { get; init; }

        [PropertyDisplay(true)][PropertyOrder(6)] public bool? IsAuditConducted { get; init; }

        [PropertyDisplay(true)][PropertyOrder(7)] public bool? HasISPRevised { get; init; }

        [PropertyDisplay(true)][PropertyOrder(8)] public int? NumberOfRevision { get; init; }
        //[PropertyOrder(10)]
        //public int YearOfRevisions { get; init; }

        
    }
}
