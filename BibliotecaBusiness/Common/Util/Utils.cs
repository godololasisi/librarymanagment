using BibliotecaBusiness.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Common.Util
{
    public static class Utils
    {
        public static SendNotificationRequestDto CreateObjectPush(RegisterBookDto data)
        {
            var sendNotification = new SendNotificationRequestDto();
            sendNotification.Title = "Libro Registrado Exitosamente";
            sendNotification.Body = $"Libro {data.NameBook} en inventario";
            sendNotification.CreatedOn = DateTime.Now;
            sendNotification.NotificationType = "P";
            sendNotification.RedirectUrl = "";

            return sendNotification;
        }
    }
}
