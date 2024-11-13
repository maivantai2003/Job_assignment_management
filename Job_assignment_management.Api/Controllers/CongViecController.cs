using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Api.Quarts;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Job_assignment_management.Shared.Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Quartz;
using Quartz.Core;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CongViecController : ControllerBase
    {
        private readonly ICongViecRepository _congViecRepository;
        private readonly IHubContext<myHub> _hubContext;
        private readonly ISchedulerFactory _schedulerFactory;

        public CongViecController(ICongViecRepository congViecRepository, IHubContext<myHub> hubContext, ISchedulerFactory schedulerFactory)
        {
            _congViecRepository = congViecRepository;
            _hubContext = hubContext;
            _schedulerFactory = schedulerFactory;
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
            try
            {
                var congViec = await _congViecRepository.GetByIdAsync(id);
                return Ok(congViec);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error = ErrorMessages.FindFailed
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCongViec(CongViecViewModel model)
        {
            try
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
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
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
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateCompleteTask(int id,bool trangThai,double mucDo)
        {
            var result=await _congViecRepository.UpdateComplete(id, trangThai,mucDo);
            return Ok(result);  
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTaskDay(int id,DateTime thoiGianKetThuc)
        {
            try
            {
                var result = await _congViecRepository.UpdateTaskDay(id, thoiGianKetThuc);
                return Ok(result);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error=ErrorMessages.UpdateDateFailed
                });
            }
        }
    }
}
