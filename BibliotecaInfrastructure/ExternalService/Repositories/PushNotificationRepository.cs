using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaInfrastructure.ExternalService.Repositories
{
    public class PushNotificationRepository : IPushNotificationRepository
    {
        private readonly IConfiguration _config;
        public PushNotificationRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendPushNotification(SendNotificationRequestDto request)
        {
            System.Uri ruta = new System.Uri(_config["Firebase:Url"]);
            var a = new
            {
                notification = new
                {
                    title = request.Title,
                    body = request.Body,
                    icon = _config["AtlanticCity:Icon"],
                    open_url = request.RedirectUrl
                },
                data = new
                {
                    open_url = request.RedirectUrl
                },
                registration_ids = request.Tokens,
                payload = new
                {
                    type = request.NotificationType,
                }
            };

            string json = JsonConvert.SerializeObject(a);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + _config[$"{request.Sender}:ServerToken"]);
                client.DefaultRequestHeaders.Add("Sender", "id = " + _config[$"{request.Sender}:SenderId"]);

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync(ruta, content);
                var resultContent = httpResponse.Content.ReadAsStringAsync().Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException($"There was an error calling the Microservice. {resultContent}");
                }
            }
        }
    }
}
