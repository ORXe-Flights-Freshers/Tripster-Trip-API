using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Tavisca.Tripster.Contracts.Interface;

namespace Tavisca.Tripster.Core.Provider
{
    public class MailBuilder : IMailBuilder
    {
        public MailAddress CreateAddress(string address, string displayName)
        {
            return new MailAddress(address, displayName);
        }

        public MailAddress CreateAddress(string address)
        {
            return new MailAddress(address);
        }

        public MailMessage CreateMessage()
        {
            return new MailMessage();
        }

    }
}
