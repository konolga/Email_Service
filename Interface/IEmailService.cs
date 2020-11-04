using EmailService.Models;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace EmailService.Interface
{
    interface IEmailService
    {
        Task<bool> SendEmailAsync(SendGridMessage emailTemplate);

        SendGridMessage BuildMessage(string emailTo, string emailFrom, string emailFromName, string subject, string content);
    }
}
