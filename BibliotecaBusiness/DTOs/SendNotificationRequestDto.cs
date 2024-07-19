using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.DTOs
{
    public class SendNotificationRequestDto
    {
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Body { get; set; }
        public string? Sender { get; set; }
        public string? NotificationType { get; set; }
        public string? ShortBody { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? RedirectUrl { get; set; }
        public List<string>? Tokens { get; set; }
    }
}
