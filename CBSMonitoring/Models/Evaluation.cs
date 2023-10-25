using CBSMonitoring.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class Evaluation
    {
        [Key] public int Id { get; set; }
        #nullable disable
        [Required]
        public string BlockNumber { get; set; }  //Quesiton block number
        [Required]
        public double Score { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int QuarterIndex { get; set; }
        public int OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }
        public DateTime EvaluatedTime { get; set; }
        #nullable enable
        public string? Comment { get; set; }

    }
}
