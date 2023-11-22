namespace CBSMonitoring.DTOs
{
    public class CompletionForPeriod
    {
        public Period Period { get; set; }
        public double? Completion { get; set; }

        public CompletionForPeriod(Period period, double? completion)
        {
            Period = period;
            Completion = completion;
        }
    }
}
