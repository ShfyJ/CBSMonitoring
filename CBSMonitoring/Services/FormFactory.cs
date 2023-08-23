using CBSMonitoring.Models;
using CBSMonitoring.Services.FormReports;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public abstract class FormFactory
    {
       public abstract Type[] GetMonitoringForm(string formNumber);
    }
}
