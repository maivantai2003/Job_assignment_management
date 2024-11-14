using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Api.Quarts;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Quartz;
using System.Security.Claims;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapLichController : ControllerBase
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IHubContext<myHub> _hubContext;
        public LapLichController(ISchedulerFactory schedulerFactory, IHubContext<myHub> hubContext)
        {
            _schedulerFactory = schedulerFactory;
            _hubContext=hubContext;
        }
        [HttpPost]
        public async Task<IActionResult> SendNotification(SendNotification notification) 
        {
            IScheduler scheduler = await _schedulerFactory.GetScheduler();
            var job = JobBuilder.Create<myQuart>()
                                .UsingJobData("TenCongViec", notification.TenCongViec)
                                .UsingJobData("MaCongViec", notification.MaCongViec + "")
                                .UsingJobData("NoiDung",notification.NoiDung)
                                .UsingJobData("Email",notification.Email)
                                .WithIdentity($"job-{notification.MaCongViec}", "group")
            .Build();
            var trigger = TriggerBuilder.Create()
                                        .WithIdentity($"trigger-{notification.MaCongViec}-{Guid.NewGuid()}", "group")
                                        .StartAt(notification.ThoiGianKetThuc.Value)
                                        .WithSimpleSchedule(x => x.WithMisfireHandlingInstructionFireNow())
                                        .Build();

            await scheduler.ScheduleJob(job, trigger);
            return Ok(true);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> TestNhanTin(int maNhanVien,string message)
        {
            await _hubContext.Clients.All.SendAsync("nhantin","Hello");
            return Ok(true);
        }
    }
}
