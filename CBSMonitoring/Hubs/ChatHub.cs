using CBSMonitoring.Constants;
using CBSMonitoring.Data;
using CBSMonitoring.Models;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web.Http;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly AppDbContext _context;
        private readonly IGenericRepository _messagRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        //private string? SenderId;
        //private string? OrgId;
        public ChatHub(AppDbContext context, IGenericRepository orgRepository, 
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _messagRepository = orgRepository;
            _userManager = userManager;
            
        }

        public override async Task OnConnectedAsync()
        {          
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine($"Connected: {Context.ConnectionId}, User ID: {userId}");
            //OrgId = Context.User?.FindFirst(CustomClaimTypes.OrganizationId)?.Value;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine("Disconnected: " + Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessageToAll(MessageRequest message)
        {
            var msgRecipients = await _context.Users.Select(u => new MessageRecipient() { UserId = u.Id }).ToListAsync();
            var user = await _userManager.FindByIdAsync(message.SenderId);
            var msg = new Message
            {
                SenderId = message.SenderId,  
                MessageHeader = message.Header,
                Content = message.Content,
                IsBroadcast = true,
                MessageRecipients = msgRecipients
            };

            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", user.FullName, message);
        }

        public async Task SendMessageToSelected(MessageRequest message)
        {
            var msg = new Message
            {
                SenderId = message.SenderId,
                MessageHeader = message.Header,
                Content = message.Content,
                MessageRecipients = message.ReceiverIds.Select(id => new MessageRecipient() { UserId = id}).ToList()
            };           

            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();
            var user = await _userManager.FindByIdAsync(message.SenderId);
            // Notify relevant clients based on user IDs
            foreach (var recipient in message.ReceiverIds)
            {

                await Clients.User(recipient).SendAsync("ReceiveMessage",user.FullName, message);
            }

        }

    }
}
