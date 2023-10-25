using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
                return BadRequest(result.Messages);

            return File(result.Data.Memory, result.Data.ContentType, result.Data.FileName);
        }

    }
}
