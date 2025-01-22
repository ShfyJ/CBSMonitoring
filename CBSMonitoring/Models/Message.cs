using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Models
{
    public class Message
    {
        public int Id { get; set; }
        #nullable disable
        public string SenderId { get; set; } 
        public string MessageHeader { get; set; }
        public string Content { get; set; }
        public bool IsBroadcast { get; set; } = false;  // Default to false for direct messages
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool VisibleForSender { get; set; } = true;
        public ApplicationUser Sender { get; set; }
        public ICollection<MessageRecipient> MessageRecipients { get; set; }
    }
}
