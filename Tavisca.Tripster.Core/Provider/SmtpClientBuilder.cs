using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Tavisca.Tripster.Contracts.Interface;

namespace Tavisca.Tripster.Core.Provider
{
    public class SmtpClientBuilder : ISmtpClientBuilder
    {
        private SmtpClient _smtpClient;

        public SmtpClientBuilder(IConfiguration config)
        {
            _smtpClient = new SmtpClient()
            {
                Host = config.GetValue<String>("Email:Smtp:Host"),
                Port = config.GetValue<int>("Email:Smtp:Port"),
                Credentials = new NetworkCredential(
                            config.GetValue<String>("Email:Smtp:Username"),
                            config.GetValue<String>("Email:Smtp:Password")
                        ),
                EnableSsl = config.GetValue<bool>("Email:Smtp:EnableSsl")
            };
        }
        public void send(MailMessage message)
        {
            _smtpClient.SendAsync(message, null);
        }
    }
}
