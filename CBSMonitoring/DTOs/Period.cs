namespace CBSMonitoring.DTOs
{
    public class Period
    {
        public int Year { get; init; } = DateTime.Now.Year;
        public int Quarter { get; init; } = (DateTime.Now.Month - 1) / 3 + 1;

        public Period(int Year, int Quarter)
        {
            this.Year = Year;
            this.Quarter = Quarter;
        }

        public Period() { }
    }
}
