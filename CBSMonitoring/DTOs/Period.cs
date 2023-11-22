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

        public override bool Equals(object? obj)
        {
            // Check for null and compare run-time types.
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Period p = (Period)obj;
            return (Year == p.Year) && (Quarter == p.Quarter);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Year, Quarter);
        }

        //// Optional: ToString override for easier debugging
        //public override string ToString()
        //{
        //    return $"Year: {Year}, Quarter: {Quarter}";
        //}
    }
}
