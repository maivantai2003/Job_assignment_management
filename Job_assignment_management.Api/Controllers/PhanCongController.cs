using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Job_assignment_management.Shared.Common.Heplers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhanCongController : ControllerBase
    {
        private readonly IPhanCongRepository _repository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHubContext<myHub> _hubContext;

        public PhanCongController(IPhanCongRepository repository, INhanVienRepository nhanVienRepository, IHubContext<myHub> hubContext)
        {
            _repository = repository;
            _nhanVienRepository = nhanVienRepository;
            _hubContext = hubContext;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPhanCongNhanVienAsync(int maNhanVien)
        {
            var list = await _repository.GetPhanCongNhanVienAsync(maNhanVien);
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhanCong(string? search, int page = 1)
        {
            var list = await _repository.GetAllAsync(search, page);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhanCongById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhanCong(PhanCongViewModel model)
        {
            var entity = new PhanCong
            {
                
                MaCongViec = model.MaCongViec,
                MaNhanVien = model.MaNhanVien,
                VaiTro = model.VaiTro,
            };
            var createdEntity = await _repository.CreateAsync(entity);
            await _hubContext.Clients.All.SendAsync("loadPhanCong");
            await _hubContext.Clients.All.SendAsync("loadCongViec");
            return Ok(createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhanCong(int id, PhanCongViewModel model)
        {
            var entity = new PhanCong
            {
                MaCongViec = model.MaCongViec,
                MaNhanVien = model.MaNhanVien,
                VaiTro = model.VaiTro,
                //TrangThai = model.TrangThai,
                TrangThaiCongViec = model.TrangThaiCongViec,
            };
            await _repository.UpdateAsync(id, entity);
            await _hubContext.Clients.All.SendAsync("updateCongViec");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhanCong(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
