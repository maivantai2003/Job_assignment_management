using Job_assignment_management.Application.Interfaces;
using Job_assignment_management.Shared.Common;
using MimeKit;
using MailKit.Net.Smtp;
namespace Job_assignment_management.Application.Services
{
    public class SendGmailService : ISendGmailService
    {
        public async Task SendGmailAsync(Gmail gmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("vantaii12082003@gmail.com", "vantaii12082003@gmail.com"));
            message.To.Add(new MailboxAddress(gmail.name, gmail.ToGmail));
            message.Subject = gmail.Subject;

            // Thiết lập nội dung email
            message.Body = new TextPart("html")
            {
                Text = gmail.Body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("vantaii12082003@gmail.com", "lgws vrot kuem nzzi");
                await client.SendAsync(message);
                client.Disconnect(true);
            }
        }
    }
}
