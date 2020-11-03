using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService
{
    public class AppConfig
    {
        public SendGridConfig SendGridConfig { get; set; }
    }

    public class SendGridConfig
    {
        public string SENDGRID_KEY { get; set; }
        public string POST_URL { get; set; }
    }
}
