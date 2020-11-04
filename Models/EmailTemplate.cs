using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService.Models
{
    public class SendGridEmail
    {
        public SendGridEmail()
        {
        }

        public SendGridEmail(string email, string name = null)
        {
            this.Email = email;
            this.Name = name;
        }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class SendGridPersonalization
    {
        [JsonProperty("to")]
        public List<SendGridEmail> To { get; set; }

        [JsonProperty("bcc")]
        public IEnumerable<SendGridEmail> Bcc { get; set; }
    }

    public class SendGridContent
    {
        public SendGridContent()
        {
        }

        public SendGridContent(string type, string content)
        {
            this.Type = type;
            this.Value = content;
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class SendGridMessage
    {
        public const string TypeText = "text";
        public const string TypeHtml = "text/html";

        public SendGridMessage()
        {
        }

        public SendGridMessage(SendGridEmail to, string subject, SendGridEmail from, string message, IEnumerable<SendGridEmail> bcc = null, string type = TypeHtml)
        {
            this.Personalizations = new List<SendGridPersonalization>
        {
            new SendGridPersonalization
            {
                To = new List<SendGridEmail> { to },
                Bcc = bcc,
                
            }
        };
          
            this.From = from;
            this.Subject = subject;
            this.Content = new List<SendGridContent> { new SendGridContent(type, message) };
        }

        [JsonProperty("personalizations")]
        public List<SendGridPersonalization> Personalizations { get; set; }


        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        [JsonProperty("from")]
        public SendGridEmail From { get; set; }

        [JsonProperty("content")]
        public List<SendGridContent> Content { get; set; }
    }

}