using CBSMonitoring.Constants;
using CBSMonitoring.Data;
using CBSMonitoring.Services.FormReports;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public class ConcreteFormFactory : FormFactory
    {
        private readonly AppDbContext context;
        private readonly IFileWorkRoom fileWorkRoom;

        public ConcreteFormFactory(AppDbContext context, IFileWorkRoom fileWorkRoom)
        {
            this.context = context;
            this.fileWorkRoom = fileWorkRoom;
        }
        public async override Task<Result<IMonitoringFactory>> GetMonitoringForm(string formNumber)
            => formNumber switch
            {
               // FormType.Form1_1 => await Result<IMonitoringFactory>.SuccessAsync(new Form1_1Report(context, fileWorkRoom)),
                //FormType.Form1_2 => await Result<IMonitoringFactory>.SuccessAsync(new Form1_2Report(context)),
                //FormType.Form1_3 => await Result<IMonitoringFactory>.SuccessAsync(new Form1_3Report(context)),
                //FormType.Form1_4 => await Result<IMonitoringFactory>.SuccessAsync(new Form1_4Report(context)),
                //FormType.Form1_5 => await Result<IMonitoringFactory>.SuccessAsync(new Form1_5Report(context)),
                _ => await Result<IMonitoringFactory>.FailAsync($"Monitoring form is not found"),
            };
    }
}
