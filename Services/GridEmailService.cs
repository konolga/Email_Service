using EmailService.Interface;
using EmailService.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Services
{
    class GridEmailService : IEmailService, IMessageService
    {
        private readonly IHttpClientFactory _clientFactory;
<<<<<<< HEAD
        private readonly IConfigurationRoot _config;
=======
        private readonly IConfiguration _config;
>>>>>>> c7f0d18... Email service


        public GridEmailService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public EmailTemplate BuildMessage(string emailTo, string emailFrom, string subject, string content)
        {
            Content Content = new Content()
            {
                Type = "text/plain",
                Value = content
            };
            EmailAddress EmailTo = new EmailAddress()
            {
                Email = emailTo
            };
            EmailAddress EmailFrom = new EmailAddress()
            {
                Email = emailFrom
            };
            List<EmailAddress> To = new List<EmailAddress>
            {
                EmailTo
            };
            Personalization Personalization = new Personalization()
            {
                To = To
            };
            List<Personalization> Personalizations = new List<Personalization>
            {
                Personalization
            };
            List<Content> Contents = new List<Content>
            {
                Content
            };

            EmailTemplate EmailMessage = new EmailTemplate()
            {
                Personalizations = Personalizations,
                From = EmailFrom,
                Subject = subject,
                Contents = Contents
            };
            return EmailMessage;
        }



        public async Task<string> SendEmailAsync(EmailTemplate EmailMessage)
        {
            try
            {
<<<<<<< HEAD
                var sendGridConfig = _config.Get<SendGridConfig>();
                string url = sendGridConfig.POST_URL;
                string apiKey = sendGridConfig.SENDGRID_KEY;
=======
                string url = _config.GetValue<string>("POST_URL");
                string apiKey = _config.GetValue<string>("SENDGRID_KEY");
>>>>>>> c7f0d18... Email service
                string json = JsonConvert.SerializeObject(EmailMessage);

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Authorization", apiKey);
                request.Headers.Add("Ccontent-type", "application/json");
                request.Content  = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"StatusCode: {response.StatusCode}";
                }
            }
            catch (Exception e)
            {
<<<<<<< HEAD
                
=======
>>>>>>> c7f0d18... Email service
                return e.GetBaseException().Message;
            }

        }

    }
}
