using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.Model;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public class MessageService : IMessageService
    {
        private readonly IGenericRepository _msgRepository;
        private readonly IMapper _mapper;
        public MessageService(IGenericRepository orgRepository, IMapper mapper)
        {
            _msgRepository = orgRepository;
            _mapper = mapper;
        }

        public async Task<Result<string>> ChangeMessageReadStatus(MessageReadRequest msgReadRequest)
        {
            var message = await _msgRepository.GetByIdAsync<Message>(msgReadRequest.MessageId);
            if (message == null)
            {
                return await Result<string>.FailAsync(StatusCodes.Status404NotFound, $"Сообщение с id={msgReadRequest.MessageId} недоступна!");
            }

            try
            {
                var messageRecipient = await _msgRepository.GetFirstByParameterAsync<MessageRecipient>(
                                                m => m.MessageId == msgReadRequest.MessageId && m.UserId == msgReadRequest.UserId);
                if (messageRecipient == null)
                    return await Result<string>.FailAsync(StatusCodes.Status404NotFound, $"Получатель не найден в списке получателей сообщения!");
                messageRecipient.IsRead = true;

                await _msgRepository.UpdateAsync(messageRecipient);
                
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, $"Успешно!");
        }

        public async Task<Result<string>> DeleteForOneSide(DeleteMsgRequest deleteMsgRequest)
        {
            var message = await _msgRepository.GetByIdAsync<Message>(deleteMsgRequest.MessageId);
            if (message == null)
            {
                return await Result<string>.FailAsync(StatusCodes.Status404NotFound, $"Сообщение с id={deleteMsgRequest.MessageId} недоступна!");
            }

            try
            {
                if (deleteMsgRequest.IsSender)
                {
                    message.VisibleForSender = false;
                    await _msgRepository.UpdateAsync(message);
                }
                else
                {
                    var messageRecipient = await _msgRepository.GetFirstByParameterAsync<MessageRecipient>(
                                                    m => m.MessageId == deleteMsgRequest.MessageId && m.UserId == deleteMsgRequest.UserId);
                    if (messageRecipient == null)
                        return await Result<string>.FailAsync(StatusCodes.Status404NotFound, $"Получатель не найден в списке получателей сообщения!");
                    messageRecipient.VisibleForRecipient = false;

                    await _msgRepository.UpdateAsync(messageRecipient);
                }
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, $"Успешно!");
        }

        public async Task<Result<string>> DeleteMessageForAll(int messageId)
        {
            var message = await _msgRepository.GetFirstByParameterAsync<Message>(m => m.Id == messageId, 
                                                                        query => query.Include(m => m.MessageRecipients));
            if (message == null)
            {
                return await Result<string>.FailAsync(StatusCodes.Status404NotFound, $"Сообщение с id={messageId} недоступна!");
            }

            try
            {
                foreach(var recipient in message.MessageRecipients)
                {
                    recipient.VisibleForRecipient = false;
                }

                message.VisibleForSender = false;

                await _msgRepository.UpdateAsync(message);

            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, $"Успешно!");
        }

        public async Task<Result<string>> DeletePermanently(int messageId)
        {
            var message = await _msgRepository.GetByIdAsync<Message>(messageId);
            if (message == null)
            {
                return await Result<string>.FailAsync(StatusCodes.Status404NotFound, $"Сообщение с id={messageId} недоступна!");
            }

            try
            {
                await _msgRepository.DeleteAsync(message);
            }
            catch(Exception ex) 
            {
                    return await Result<string>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);

            }
            
            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, $"Успешно!");
        }

        public async Task<Result<IEnumerable<InboxMessage>>> GetInboxByUserId(string receiverId)
        {
            try
            {
                var messageForUsers = await _msgRepository.GetAllAsync<Message>(m => m.MessageRecipients.Any(r => r.UserId == receiverId && r.VisibleForRecipient)
                                                                                                       && m.Sender!= null,
                                                                                            query => query.Include(m => m.MessageRecipients)
                                                                                                          .Include(m => m.Sender));

                return await Result<IEnumerable<InboxMessage>>.SuccessAsync(StatusCodes.Status200OK,
                   _mapper.Map<IEnumerable<InboxMessage>>(messageForUsers, opt => { opt.Items["UserId"] = receiverId; }));
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<InboxMessage>>.SuccessAsync(StatusCodes.Status400BadRequest,
                   ex.Message);
            }
            
        }

        public async Task<Result<IEnumerable<SentMessage>>> GetSentMessagesByUserId(string userId)
        {
            try
            {
                var messageForUsers = await _msgRepository.GetAllAsync<Message>(m => m.SenderId == userId && m.VisibleForSender,
                                                                                query => query.Include(m => m.MessageRecipients)
                                                                                .ThenInclude(r => r.Recipient));

                return await Result<IEnumerable<SentMessage>>.SuccessAsync(StatusCodes.Status200OK,
                   _mapper.Map<IEnumerable<SentMessage>>(messageForUsers));
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<SentMessage>>.SuccessAsync(StatusCodes.Status400BadRequest,
                  ex.Message);
            }
            
        }
    }
}
