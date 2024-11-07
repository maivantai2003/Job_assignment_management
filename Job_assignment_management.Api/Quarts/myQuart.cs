using Job_assignment_management.Api.Hubs;
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
            await _hubContext.Clients.All.SendAsync("task",$"Công việc {tenCongViec} sẽ hết hạn sau 1 ngày");
        }
    }
}
