using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public abstract class FormFactory
    {
        public abstract Task<Result<Type[]>> GetMonitoringForm(string formNumber, int argCount);
    }
}
