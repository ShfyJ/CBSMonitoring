using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.Model;
using CBSMonitoring.Models.Forms;
using CBSMonitoring.Services;
using CBSMonitoring.Services.FormReports;
using ERPBlazor.Shared.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Runtime.CompilerServices;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringsController : ControllerBase
    {
        private readonly FormFactory _formFactory;
        private readonly IMonitoringFactory _monitoringFactory;
        private readonly Type _classType;       
        public MonitoringsController(IGenericRepository gr, IMapper mp, IFileWorkRoom fw)
        {
            _formFactory = new ConcreteFormFactory();
            _monitoringFactory = new FormReportService(gr, fw, mp);
            _classType = typeof(IMonitoringFactory);

        }

        [HttpPost("AddReport/{sectionNumber}")]
        public async Task<IActionResult> AddReport([FromForm] MonitoringDTO monitoringDTO, string sectionNumber)
        {
            object[] args = { monitoringDTO, sectionNumber };
            string methodName = nameof(IMonitoringFactory.AddMonitoringReport);

            return await InvokeGenericMethod(sectionNumber, methodName, args);
        }

        [HttpPost("GetQuaterReport")]
        public async Task<IActionResult> GetQuaterReport([FromBody] ReportRequest reportRequest)
        {

            object[] args = { reportRequest };
            string methodName = nameof(IMonitoringFactory.GetQuaterReport);

            return await InvokeGenericMethod(reportRequest.sectionNumber, methodName, args);
        }

        [HttpPost("UpdateReport/{sectionNumber}/{id}")]
        public async Task<IActionResult> UpdateReport(string sectionNumber, int monitoringId, [FromForm] MonitoringDTO monitoringDTO)
        {

            object[] args = {monitoringDTO, monitoringId };
            string methodName = nameof(IMonitoringFactory.EditMonitoringReport);

            return await InvokeGenericMethod(sectionNumber, methodName, args);
        }

        [HttpDelete("DeleteReport/{sectionNumber}/{id}")]
        public async Task<IActionResult> DeleteReport(string sectionNumber, int monitoringId)
        {

            object[] args = { monitoringId };
            string methodName = nameof(IMonitoringFactory.DeleteMonitoringReport);

            return await InvokeGenericMethod(sectionNumber, methodName, args);
        }

        private async Task<IActionResult> InvokeGenericMethod(string sectionNumber, string methodName, object[] args)
        {
            try
            {
                // => Getting OrgMonitoring child entity type
                var formType = _formFactory.GetMonitoringForm(sectionNumber);

                // => Getting IMonitoringFactory.AddMonitoringReport<T> generic method reflection
                MethodInfo methodInfo = _classType.GetMethod(methodName)!.MakeGenericMethod(formType);

                //Invoking generic method
                var task = (Task)methodInfo.Invoke(_monitoringFactory, args)!;
                await task.ConfigureAwait(false);
                var taskProperty = task.GetType().GetProperty("Result");
                //Getting Result<T> object
                var returnedObject = taskProperty!.GetValue(task)!;
                var objectProperty = returnedObject.GetType().GetProperty(nameof(Result.Succeeded));

                if (objectProperty is null)
                {
                    return BadRequest();
                }

                if (!Convert.ToBoolean(objectProperty!.GetValue(returnedObject)))
                    return BadRequest(returnedObject.GetType().GetProperty(nameof(Result.Messages))!.GetValue(returnedObject));

                return Ok(returnedObject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
