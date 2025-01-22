using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequirePasswordChange")]
    public class FileModelsController : ControllerBase
    {
        private readonly IFileWorkRoom _fileWorkRoom;
        public FileModelsController(IFileWorkRoom fileWorkRoom)
        {
            _fileWorkRoom = fileWorkRoom;
        }

        [HttpGet("GetFile/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var result = await _fileWorkRoom.GetFileAsStream(id);

            if (!result.Succeeded)
                return StatusCode(result.StatusCode, result);

            return File(result.Data!.Memory, result.Data.ContentType, result.Data.FileName);
        }

        [HttpPost("AddCatalogs")]
        public async Task<IActionResult> AddCatalogs([FromForm]CatalogFile catalog)
        {
            var result = await _fileWorkRoom.AddCatalogs(catalog);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("GetCatalogs")]
        public async Task<IActionResult> GetCatalogs()
        {
            var result = await _fileWorkRoom.GetCatalogs();
            return StatusCode(result.StatusCode, result);
        }

    }
}
