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
using CBSMonitoring.Constants;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequirePasswordChange")]
    public class MonitoringReportsController : ControllerBase
    {
        private readonly FormFactory _formFactory;
        private readonly IMonitoringFactory _monitoringFactory;
        private readonly Type _classType;
        private record Error(List<string> Messages);
        public MonitoringReportsController(IMonitoringFactory monitoringFactory)
        {
            _formFactory = new ConcreteFormFactory();
            _monitoringFactory = monitoringFactory;
            //_monitoringFactory = new FormReportService(gr, fw, mp);
            _classType = typeof(IMonitoringFactory);

        }
        
        [HttpPost("AddReport/{sectionNumber}")]
        public async Task<IActionResult> AddReport([FromForm] MultipartFormDataWithMultipleFiles<MonitoringDto> monitoringReport, string sectionNumber)
        {
            var args = monitoringReport.FileItems == null
                ? new object[]{ monitoringReport.Json, sectionNumber} 
                : new object[]{ monitoringReport.Json, sectionNumber, monitoringReport.FileItems};

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
        
        [HttpPost("GetQuarterReportByQb")]
        public async Task<IActionResult> GetQuarterReportByQb([FromBody] ReportRequestByQb reportRequest)
        {

            var result = await _monitoringFactory.GetQuarterReportByQb(reportRequest);

            return StatusCode(result.StatusCode, result);
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
                // Getting OrgMonitoring child entity type
                var formTypeResult = await _formFactory.GetMonitoringForm(sectionNumber, typeCount);

                if (!formTypeResult.Succeeded)
                {
                    return StatusCode(formTypeResult.StatusCode, formTypeResult);
                }

                // Getting IMonitoringFactory.AddMonitoringReport<T> generic method reflection
                MethodInfo methodInfo = _classType.GetMethod(methodName)!.MakeGenericMethod(formTypeResult.Data!);

                // Invoking generic method
                var task = (Task)methodInfo.Invoke(_monitoringFactory, args)!;
                await task.ConfigureAwait(false);
                var taskProperty = task.GetType().GetProperty("Result");

                var returnedObject = taskProperty!.GetValue(task)!;

                return StatusCode((int)returnedObject.GetType().GetProperty(nameof(Result.StatusCode))!
                    .GetValue(returnedObject)!, returnedObject);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
