using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Tripster.Contracts.Interface
{
    public interface ISmtpClientBuilder
    {
        Task send(MailMessage message);
    }
}
