using Job_assignment_management.Api.Quarts;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapLichController : ControllerBase
    {
        private readonly ISchedulerFactory _schedulerFactory;
        public LapLichController(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
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
                                        .WithIdentity($"trigger-{notification.MaCongViec}", "group")
                                        .StartAt(notification.ThoiGianKetThuc.Value)
                                        .WithSimpleSchedule(x => x.WithMisfireHandlingInstructionFireNow())
                                        .Build();

            await scheduler.ScheduleJob(job, trigger);
            return Ok(true);
        }
    }
}
