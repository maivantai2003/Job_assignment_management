using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Job_assignment_management.Shared.Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepository _taiKhoanRepository;
        private readonly IHubContext<myHub> _hubContext;
        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository, IHubContext<myHub> hubContext)
        {
            _taiKhoanRepository = taiKhoanRepository;
            _hubContext = hubContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTaiKhoan(string? search, int page = 1)
        {
            var listTaiKhoan = await _taiKhoanRepository.GetAllAsync(search, page);
            return Ok(listTaiKhoan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaiKhoanById(int id)
        {
            var taiKhoan = await _taiKhoanRepository.GetByIdAsync(id);
            return Ok(taiKhoan);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTaiKhoan(TaiKhoanViewModel model)
        {
            var taiKhoan = new TaiKhoan
            {
                MaNhanVien = model.MaNhanVien,
                TenTaiKhoan = model.TenTaiKhoan,
                MatKhau = model.MatKhau,
                MaNhomQuyen = model.MaNhomQuyen
            };
            var result = await _taiKhoanRepository.CreateAsync(taiKhoan);
            await _hubContext.Clients.All.SendAsync("loadTaiKhoan");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaiKhoan(int id, TaiKhoanViewModel model)
        {
            var taiKhoan = new TaiKhoan
            {
                TenTaiKhoan = model.TenTaiKhoan,
                MatKhau = model.MatKhau,
                MaNhomQuyen = model.MaNhomQuyen
            };
            var result = await _taiKhoanRepository.UpdateAsync(id, taiKhoan);
            await _hubContext.Clients.All.SendAsync("loadTaiKhoan");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(int id)
        {
            try
            {
                var result = await _taiKhoanRepository.DeleteAsync(id);
                await _hubContext.Clients.All.SendAsync("loadTaiKhoan");
                return Ok(result);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    Error = ErrorMessages.DeleteFailed
                });
            }
        }
    }
}
