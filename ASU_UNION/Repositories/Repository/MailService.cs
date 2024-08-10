using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ASU_UNION.Repositories.Repository
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmail(string to, string subject)
        {
            var email = new MimeMessage()
            {
                Sender = MailboxAddress.Parse(_mailSettings.email),
                Subject = subject,
            };

            var builder = new BodyBuilder();
            
            var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\emailMessage.html";
            var str = new StreamReader(filePath);
            
           
           
                var mailText = str.ReadToEnd();
                str.Close();
                mailText = mailText.Replace("[UserName]", to);
                //builder.HtmlBody = mailText;
                email.To.Add(MailboxAddress.Parse(to));
            //email.Body = builder.ToMessageBody();



            builder.HtmlBody = mailText ;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettings.displayName,_mailSettings.email));
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.host, _mailSettings.port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.email, _mailSettings.password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
            
        }
    }
}
