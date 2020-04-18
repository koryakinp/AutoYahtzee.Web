using AutoYahtzee.Business.DTO;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AutoYahtzee.Business
{
    public class SendGridManager
    {
        private readonly SendGridClient _sendGridClient;
        private readonly SendGridConfigOptions _sendGridConfig;

        public SendGridManager(IOptions<SendGridConfigOptions> config)
        {
            _sendGridConfig = config.Value;
            _sendGridClient = new SendGridClient(_sendGridConfig.Key);
        }

        public async Task<bool> SendEmail(ContactEntry entry)
        {
            var from = new EmailAddress(entry.Email, entry.Name);
            var subject = "Auto Yahtzee Contact Form";
            var to = new EmailAddress(_sendGridConfig.Recepient);
            string plainTextContent = entry.Message;
            string template = File
                .ReadAllText("email-template.html")
                .Replace("{{Email}}", entry.Email)
                .Replace("{{Name}}", entry.Name)
                .Replace("{{Message}}", entry.Message);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, template);
            var response = await _sendGridClient.SendEmailAsync(msg);
            return response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}
