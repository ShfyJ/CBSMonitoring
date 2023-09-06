using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
using CBSMonitoring.Services.FormReports;
using ERPBlazor.Shared.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using static CBSMonitoring.DTOs.Requests;
using CBSMonitoring.Helpers;
using CBSMonitoring.Wrappers;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport.Models;

namespace CBSMonitoring.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringReportsController : ControllerBase
    {
        private readonly FormFactory _formFactory;
        private readonly IMonitoringFactory _monitoringFactory;
        private readonly Type _classType;
        public MonitoringReportsController(IGenericRepository gr, IMapper mp, IFileWorkRoom fw)
        {
            _formFactory = new ConcreteFormFactory();
            _monitoringFactory = new FormReportService(gr, fw, mp);
            _classType = typeof(IMonitoringFactory);

        }

        
        [HttpPost("AddReport/{sectionNumber}")]
        public async Task<IActionResult> AddReport([FromForm] MultipartFormDataWithMultipleFiles<MonitoringDto> monitoringReport, string sectionNumber)
        {
            object[] args = { monitoringReport.Json, sectionNumber };
            const string methodName = nameof(IMonitoringFactory.AddMonitoringReport);

            return await InvokeGenericMethod(sectionNumber, methodName, args, 1);
        }

        [HttpPost("GetQuarterReport")]
        public async Task<IActionResult> GetQuarterReport([FromBody] ReportRequest reportRequest)
        {

            object[] args = { reportRequest };
            const string methodName = nameof(IMonitoringFactory.GetQuarterReport);

            return await InvokeGenericMethod(reportRequest.SectionNumber, methodName, args, 2);
        }

        [HttpPost("UpdateReport/{sectionNumber}")]
        public async Task<IActionResult> UpdateReport(string sectionNumber, int monitoringId, [FromForm] MonitoringDto monitoringDto)
        {

            object[] args = { monitoringDto, monitoringId };
            const string methodName = nameof(IMonitoringFactory.EditMonitoringReport);

            return await InvokeGenericMethod(sectionNumber, methodName, args, 1);
        }

        [HttpDelete("DeleteReport/{sectionNumber}/")]
        public async Task<IActionResult> DeleteReport(string sectionNumber, int monitoringId)
        {

            object[] args = { monitoringId };
            const string methodName = nameof(IMonitoringFactory.DeleteMonitoringReport);

            return await InvokeGenericMethod(sectionNumber, methodName, args, 1);
        }

        private async Task<IActionResult> InvokeGenericMethod(string sectionNumber, string methodName, object[] args, int typeCount)
        {
            try
            {
                // => Getting OrgMonitoring child entity type
                var formType = _formFactory.GetMonitoringForm(sectionNumber, typeCount);

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
