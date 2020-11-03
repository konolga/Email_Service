using EmailService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Interface
{
    interface IMessageService
    {
        EmailTemplate BuildMessage(string emailTo, string emailFrom, string subject, string content);
    }
}
