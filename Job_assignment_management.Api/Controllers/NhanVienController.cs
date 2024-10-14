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
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHubContext<myHub> _hubContext;
        public NhanVienController(INhanVienRepository nhanVienRepository, IHubContext<myHub> hubContext)
        {
            _nhanVienRepository = nhanVienRepository;
            _hubContext = hubContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNhanVien(string? search, int page = 1)
        {
            var listNhanVien = await _nhanVienRepository.GetAllAsync(search, page);
            return Ok(listNhanVien);
        }

        // GET: api/NhanVien/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhanVienById(int id)
        {
            var nhanVien = await _nhanVienRepository.GetByIdAsync(id);
            return Ok(nhanVien);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNhanVien(NhanVienViewModel model)
        {
            var nhanVien = new NhanVien
            {
                TenNhanVien = model.TenNhanVien,
                TenChucVu = model.TenChucVu,
                SoDienThoai = model.SoDienThoai,
                Email = model.Email,
                MaPhongBan = model.MaPhongBan
            };
            var result = await _nhanVienRepository.CreateAsync(nhanVien);
            await _hubContext.Clients.All.SendAsync("loadEmployee");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhanVien(int id, NhanVienViewModel model)
        {
            var nhanVien = new NhanVien
            {
                TenNhanVien = model.TenNhanVien,
                TenChucVu = model.TenChucVu,
                SoDienThoai = model.SoDienThoai,
                Email = model.Email,
                MaPhongBan = model.MaPhongBan
            };
            var result = await _nhanVienRepository.UpdateAsync(id, nhanVien);
            await _hubContext.Clients.All.SendAsync("loadEmployee");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(int id)
        {
            var result = await _nhanVienRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
