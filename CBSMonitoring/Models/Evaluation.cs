using CBSMonitoring.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBSMonitoring.Models
{
    public class Evaluation
    {
        [Key] public int Id { get; set; }
        #nullable disable
        [Required(ErrorMessage = "Требуется номер блока вопросов")]
        public string BlockNumber { get; set; }  //Quesiton block number
        [Required(ErrorMessage = "Требуется оценка")]
        public double Score { get; set; }
        [Required]
        [Range(2000, 2100, ErrorMessage = "Год вне диапазона (2000-2100)")]
        public int Year { get; set; }
        [Required]
        [Range(1, 4, ErrorMessage = "Неверный номер квартала")]
        public int QuarterIndex { get; set; }
        public int OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }
        public DateTime EvaluatedTime { get; set; }
        #nullable enable
        public string? Comment { get; set; }

    }
}
