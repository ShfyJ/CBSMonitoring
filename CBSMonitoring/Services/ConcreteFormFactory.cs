using CBSMonitoring.Constants;
using CBSMonitoring.Data;

namespace CBSMonitoring.Services
{
    public class ConcreteFormFactory : FormFactory
    {
        private readonly AppDbContext context;
        public override IMonitoringFactory GetMonitoringForm(string formNumber)
            => formNumber switch
            {
                FormType.Form1_1 => new Form1_1Report(context) 
            };
    }
}
