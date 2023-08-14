using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public abstract class FormFactory
    {
        public abstract Task<Result<IMonitoringFactory>> GetMonitoringForm(string formNumber);
    }
}
