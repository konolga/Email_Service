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
    public class GridEmailService : IEmailService
    {
        private readonly IHttpClientFactory _clientFactory;
        private IConfiguration _config;


        public GridEmailService(IHttpClientFactory clientFactory, IConfiguration configRoot)
        {
            _clientFactory = clientFactory;
            _config = (IConfigurationRoot)configRoot;
        }

        public SendGridMessage BuildMessage(string emailTo, string emailFrom, string emailFromName, string subject, string emailBody)
        {
            SendGridMessage msg = new SendGridMessage(
            new SendGridEmail(emailTo),
            subject,
            new SendGridEmail(emailFrom, emailFromName),
            emailBody);
            return msg;
        }



        public async Task<bool> SendEmailAsync(SendGridMessage EmailMessage)
        {
            try
            {
                var sendGridConfig = _config.Get<AppConfig>().SendGridConfig;
                string url = sendGridConfig.POST_URL;
                string apiKey = sendGridConfig.SENDGRID_KEY;
                string json = JsonConvert.SerializeObject(EmailMessage);

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Authorization", apiKey);
                request.Headers.Add("Ccontent-type", "application/json");
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }

        }

    }
}
