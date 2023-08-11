namespace CBSMonitoring.Services
{
    public abstract class FormFactory
    {
        public abstract IMonitoringFactory GetMonitoringForm(string formNumber);
    }
}
