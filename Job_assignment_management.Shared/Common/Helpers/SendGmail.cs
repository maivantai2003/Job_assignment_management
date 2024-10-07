using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Job_assignment_management.Shared.Common.Heplers
{
    public class SendGmail
    {
        public static async Task Send(string name, string ToGmail, string Subject, string Body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("vantaii12082003@gmail.com", "vantaii12082003@gmail.com"));
            message.To.Add(new MailboxAddress(name, ToGmail));
            message.Subject = Subject;

            // Thiết lập nội dung email
            message.Body = new TextPart("html")
            {
                Text = Body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("vantaii12082003@gmail.com", "lgws vrot kuem nzzi");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
