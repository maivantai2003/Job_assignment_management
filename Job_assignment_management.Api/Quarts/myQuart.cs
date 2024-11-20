using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Shared.Common.Heplers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Quartz;

namespace Job_assignment_management.Api.Quarts
{
    public class myQuart : IJob
    {
        private readonly IHubContext<myHub> _hubContext;
        public myQuart(IHubContext<myHub> hubContext)
        {
            _hubContext=hubContext; 
        }   
        public async Task Execute(IJobExecutionContext context)
        {
            var tenCongViec = context.JobDetail.JobDataMap.GetString("TenCongViec");
            var maCongViec = context.JobDetail.JobDataMap.GetString("MaCongViec");
            var listEmail = context.JobDetail.JobDataMap.GetString("Email");
            var noiDung = context.JobDetail.JobDataMap.GetString("NoiDung");
            await _hubContext.Clients.All.SendAsync("task",$"Công việc {tenCongViec} sẽ hết hạn sau 1 ngày {listEmail}");
            var emailArray = listEmail?.Split(',') ?? Array.Empty<string>();
            var sendEmailTasks = new List<Task>();

            foreach (var email in emailArray)
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    sendEmailTasks.Add(SendGmail.Send("ABCD",email,"Thông Báo Công Việc",noiDung));
                }
            }
            await Task.WhenAll(sendEmailTasks);
        }

    }
}
