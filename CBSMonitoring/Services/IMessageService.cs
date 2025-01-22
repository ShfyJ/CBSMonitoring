using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IMessageService
    {
        Task<Result<IEnumerable<InboxMessage>>> GetInboxByUserId(string receiverId); 
        Task<Result<IEnumerable<SentMessage>>> GetSentMessagesByUserId(string senderId);
        Task<Result<string>> ChangeMessageReadStatus(MessageReadRequest msgReadRequest);
        Task<Result<string>> DeleteMessageForAll(int messageId);
        Task<Result<string>> DeleteForOneSide(DeleteMsgRequest deleteMsgRequest);
        Task<Result<string>> DeletePermanently(int messageId);
    }
}
