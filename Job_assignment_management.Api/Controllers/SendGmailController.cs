using Job_assignment_management.Application.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendGmailController : ControllerBase
    {
        private readonly ISendGmailService _sendGmailService;
        public SendGmailController(ISendGmailService sendGmailService)
        {
            _sendGmailService = sendGmailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendGmail(Gmail gmail)
        {
            await _sendGmailService.SendGmailAsync(gmail);
            return Ok(new
            {
                Message= "Email sent successfully!"
            });
        }
    }
}
