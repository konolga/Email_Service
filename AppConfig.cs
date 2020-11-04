namespace EmailService
{
    public class AppConfig
    {
        public SendGridConfig SendGridConfig { get; set; }
        public IcanhazdadjokeConfig IcanhazdadjokeConfig { get; set; }
    }

    public class SendGridConfig
    {
        public string SENDGRID_KEY { get; set; }
        public string POST_URL { get; set; }
    }
    public class IcanhazdadjokeConfig
    {
        public string GET_URL { get; set; }
    }
}
