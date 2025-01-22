using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Models
{
    public class MessageRecipient
    {
        public int MessageId { get; set; }
        #nullable disable
        public string UserId { get; set; }
        public bool IsRead { get; set; } = false; //Default to false: unread status
        public bool VisibleForRecipient { get; set; } = true;
        public Message Message { get; set; }
        public ApplicationUser Recipient { get; set; }
    }
}
