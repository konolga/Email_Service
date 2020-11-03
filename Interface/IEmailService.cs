using EmailService.Models;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace EmailService.Interface
{
    interface IEmailService
    {
        Task<string> SendEmailAsync(EmailTemplate emailTemplate); 
    }
}
