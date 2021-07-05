using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Tavisca.Tripster.Contracts.Interface
{
    public interface IMailBuilder
    {
        MailAddress CreateAddress(string address, string displayName);
        MailAddress CreateAddress(string address);
        MailMessage CreateMessage();
    }
}
