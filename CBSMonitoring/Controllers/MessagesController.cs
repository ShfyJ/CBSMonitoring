using CBSMonitoring.Data;
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
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(IMessageService messageService, ILogger<MessagesController> logger)
        {
            _logger = logger;
            _messageService = messageService;  
        }

        [HttpGet("GetInbox/userId")]
        public async Task<IActionResult> GetInbox(string userId)
        {
            var result = await _messageService.GetInboxByUserId(userId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetSentMessages/userId")]
        public async Task<IActionResult> GetSentMessages(string userId)
        {
            var result = await _messageService.GetSentMessagesByUserId(userId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("ChangeMessageReadStatus")]
        public async Task<IActionResult> ChangeMessageReadStatus([FromBody]MessageReadRequest msgReadRequest)
        {
            var result = await _messageService.ChangeMessageReadStatus(msgReadRequest);
            return StatusCode(result.StatusCode, result);
        }


        [HttpPost("DeleteForOneSide")]
        public async Task<IActionResult> DeleteForOneSide([FromBody]DeleteMsgRequest deleteMsgRequest)
        {
            var result = await _messageService.DeleteForOneSide(deleteMsgRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("DeleteForAll")]
        public async Task<IActionResult> DeleteForAll(int messageId)
        {
            var result = await _messageService.DeleteMessageForAll(messageId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("DeletePermanently")]
        public async Task<IActionResult> DeletePermanently(int messageId)
        {
            var result = await _messageService.DeletePermanently(messageId);
            return StatusCode(result.StatusCode, result);
        }
    }
}
