using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Tavisca.Tripster.Contracts.Interface
{
    public interface ISmtpClientBuilder
    {
        void send(MailMessage message);
    }
}
