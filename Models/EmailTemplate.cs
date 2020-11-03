using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService.Models
{
    public class EmailTemplate
    {
        [JsonProperty(PropertyName = "personalizations", IsReference = false)]
        public List<Personalization> Personalizations { get; set; }

        [JsonProperty(PropertyName = "from")]
        public EmailAddress From { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "content", IsReference = false)]
        public List<Content> Contents { get; set; }
    }

    public class Content
    {
        public string Type { get; set; }

        public string Value { get; set; }
    }

    public class Personalization
    {
        public List<EmailAddress> To { get; set; }
    }

    public class EmailAddress
    {
        public string Email { get; set; }
    }
}