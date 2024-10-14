using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Api.Quarts;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Quartz;
using Quartz.Core;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongViecController : ControllerBase
    {
        private readonly ICongViecRepository _congViecRepository;
        private readonly IHubContext<myHub> _hubContext;
        private readonly ISchedulerFactory _schedulerFactory;

        public CongViecController(ICongViecRepository congViecRepository, IHubContext<myHub> hubContext, ISchedulerFactory schedulerFactory)
        {
            _congViecRepository = congViecRepository;
            _hubContext = hubContext;
            _schedulerFactory= schedulerFactory;    
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCongViec(string? search, int page = 1)
        {
            var listCongViec = await _congViecRepository.GetAllAsync(search, page);
            return Ok(listCongViec);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCongViecById(int id)
        {
            var congViec = await _congViecRepository.GetByIdAsync(id);
            return Ok(congViec);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCongViec(CongViecViewModel model)
        {
            var congViec = new CongViec
            {
                MaPhanDuAn = model.MaPhanDuAn,
                MaCongViecCha = model.MaCongViecCha,
                TenCongViec = model.TenCongViec,
                MoTa = model.MoTa,
                MucDoUuTien = model.MucDoUuTien,
                ThoiGianBatDau = model.ThoiGianBatDau,
                ThoiGianKetThuc = model.ThoiGianKetThuc,
                TrangThaiCongViec = model.TrangThaiCongViec,
                MucDoHoanThanh = model.MucDoHoanThanh
            };
            var result = await _congViecRepository.CreateAsync(congViec);
            await _hubContext.Clients.All.SendAsync("loadCongViec");
            //var triggerTime = model.ThoiGianKetThuc.HasValue
            //            ? model.ThoiGianKetThuc.Value.AddHours(-7).AddMinutes(-1)
            //            : DateTime.Now.AddDays(1).AddHours(-7);
            IScheduler scheduler = await _schedulerFactory.GetScheduler();
            var job = JobBuilder.Create<myQuart>()
                                .UsingJobData("TenCongViec", result.TenCongViec)
                                .UsingJobData("MaCongViec", result.MaCongViec+"")
                                .WithIdentity($"job-{result.MaCongViec}", "group2")
                                .Build();

            var trigger = TriggerBuilder.Create()
                                        .WithIdentity($"trigger-{result.MaCongViec}", "group2")
                                        .StartAt(model.ThoiGianKetThuc.Value)
                                        .WithSimpleSchedule(x => x.WithMisfireHandlingInstructionFireNow())
                                        .Build();

            await scheduler.ScheduleJob(job, trigger);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCongViec(int id, CongViecViewModel model)
        {
            var congViec = new CongViec
            {
                TenCongViec = model.TenCongViec,
                MoTa = model.MoTa,
                MucDoUuTien = model.MucDoUuTien,
                ThoiGianBatDau = model.ThoiGianBatDau,
                ThoiGianKetThuc = model.ThoiGianKetThuc,
                TrangThaiCongViec = model.TrangThaiCongViec,
                MucDoHoanThanh = model.MucDoHoanThanh
            };
            var result = await _congViecRepository.UpdateAsync(id, congViec);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongViec(int id)
        {
            var result = await _congViecRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
