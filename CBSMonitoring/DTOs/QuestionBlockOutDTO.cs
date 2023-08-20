using CBSMonitoring.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.ComponentModel.DataAnnotations;

namespace CBSMonitoring.DTOs
{
    public class QuestionBlockOutDTO
    {
        public int BlockId { get; set; }
        #nullable disable
        public string BlockNumber { get; set; }
        public string BlockName { get; set; }
        public bool IsActive { get; set; }
        public string[] SectionNames { get; set; }
    }
    
}
