using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongViecController : ControllerBase
    {
        private readonly ICongViecRepository _congViecRepository;
        private readonly IHubContext<myHub> _hubContext;

        public CongViecController(ICongViecRepository congViecRepository, IHubContext<myHub> hubContext)
        {
            _congViecRepository = congViecRepository;
            _hubContext = hubContext;
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
