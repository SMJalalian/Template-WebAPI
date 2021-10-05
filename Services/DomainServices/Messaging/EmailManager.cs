
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
        private readonly GlobalSettings _siteSettings;

        public EmailManager(IOptionsSnapshot<GlobalSettings> siteSettings)
        {
            _siteSettings = siteSettings.Value;
        }

        public ApiResult SendEmail(EmailDto sendEmailDto, CancellationToken cancellationToken)
        {
            try
            {
                SmtpClient client = new(_siteSettings.MailSettings.ServerDNSName);
                client.Credentials = new NetworkCredential(_siteSettings.MailSettings.UserName, _siteSettings.MailSettings.Password);
                MailMessage mailMessage = new();
                mailMessage.Subject = sendEmailDto.Subject;
                mailMessage.From = new MailAddress(_siteSettings.MailSettings.UserName, sendEmailDto.SenderName);
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



