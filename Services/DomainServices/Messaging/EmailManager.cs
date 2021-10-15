
using Microsoft.Extensions.Options;
using MyProject.Configuration;
using MyProject.Services.DTOs.Messaging;
using MyProject.Shared.API;
using MyProject.Shared.Exceptions;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace MyProject.Services.DomainServices.Messaging
{
    public class EmailManager
    {
        private readonly GlobalSettings _globalSettings;

        public EmailManager(IOptionsMonitor<GlobalSettings> globalSettings)
        {
            _globalSettings = globalSettings.CurrentValue;
        }

        public ApiResult SendEmail(EmailDto sendEmailDto, CancellationToken cancellationToken)
        {
            try
            {
                SmtpClient client = new(_globalSettings.MailSettings.ServerDNSName);
                client.Credentials = new NetworkCredential(_globalSettings.MailSettings.UserName, _globalSettings.MailSettings.Password);
                MailMessage mailMessage = new();
                mailMessage.Subject = sendEmailDto.Subject;
                mailMessage.From = new MailAddress(_globalSettings.MailSettings.UserName, sendEmailDto.SenderName);
                mailMessage.To.Add(sendEmailDto.RecieverEmail);
                mailMessage.IsBodyHtml = sendEmailDto.IsBodyHtml;
                mailMessage.Body = sendEmailDto.Body;
                client.SendAsync(mailMessage, cancellationToken);
                return ApiResult.Ok();
            }
            catch (Exception)
            {
                throw new AppException(HttpStatusCode.InternalServerError);
            }
        }
    }
}



