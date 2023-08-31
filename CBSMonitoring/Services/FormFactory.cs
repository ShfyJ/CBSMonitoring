namespace CBSMonitoring.Services
{
    public abstract class FormFactory
    {
        public abstract Type[] GetMonitoringForm(string formNumber, int argCount);
    }
}
