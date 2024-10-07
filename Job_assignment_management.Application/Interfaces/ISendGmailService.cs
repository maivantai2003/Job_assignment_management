using Job_assignment_management.Shared.Common;
namespace Job_assignment_management.Application.Interfaces
{
    public interface ISendGmailService
    {
        public Task SendGmailAsync(Gmail gmail);
    }
}
