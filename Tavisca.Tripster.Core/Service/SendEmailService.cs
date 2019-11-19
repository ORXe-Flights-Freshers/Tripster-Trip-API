using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using Tavisca.Tripster.Contracts.Entity;
using Tavisca.Tripster.Contracts.Interface;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Core.Service
{
    public class SendEmailService
    {
        private ISmtpClientBuilder _smtpClient;
        private IMailBuilder _emailClient;
        private SendCredentials _sendCredentials;
        private EmailResponse _emailResponse;
        private readonly ILogger<SendEmailService> _logger;
        public SendEmailService(ISmtpClientBuilder smtpClient, IMailBuilder emailClient,
                                SendCredentials sendCredentials, EmailResponse emailResponse,
                                ILogger<SendEmailService> logger)
        {
            _smtpClient = smtpClient;
            _emailClient = emailClient;
            _emailResponse = emailResponse;
            _sendCredentials = sendCredentials;
            _logger = logger;
        }

        public async Task<EmailResponse> Send(EmailMessage emailMessage)
        {
            try
            {
                var from = _emailClient.CreateAddress(_sendCredentials.Email, _sendCredentials.DisplayName);
                var mailMessage = _emailClient.CreateMessage();
                var to_set = new HashSet<string>(emailMessage.To);
                foreach (var recipient in to_set)
                    mailMessage.To.Add(_emailClient.CreateAddress(recipient));
                mailMessage.From = from;
                mailMessage.Subject = emailMessage.Subject;
                mailMessage.Body = emailMessage.Body;
                await Task.Run(() => _smtpClient.send(mailMessage));
                _emailResponse.IsSuccess = true;
                _emailResponse.Message = $"Email sent successfully";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _emailResponse.IsSuccess = false;
                _emailResponse.Message = $"Error sending email. Please try again later";
            }
            return _emailResponse;
        }
    }
}
