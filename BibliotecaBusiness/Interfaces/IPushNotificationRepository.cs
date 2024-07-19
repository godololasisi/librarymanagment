using BibliotecaBusiness.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Interfaces
{
    public interface IPushNotificationRepository
    {
        Task SendPushNotification(SendNotificationRequestDto request);
    }
}
