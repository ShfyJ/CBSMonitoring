namespace CBSMonitoring.DTOs
{
    public class ScoreForPeriod
    {
        public int Year {get; set;}
        public int Quarter { get; set; }
        public double? OverallScore { get; set; }
        public double? ScorePercentage { get; set; }

        public ScoreForPeriod(int year, int quarter, double? overallScore, double? scorePercentage)
        {
            Year = year;
            Quarter = quarter;
            OverallScore = overallScore;
            ScorePercentage = scorePercentage;
        }
    }
}
