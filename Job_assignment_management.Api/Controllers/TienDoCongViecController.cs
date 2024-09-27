using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TienDoCongViecController : ControllerBase
    {
        private readonly ITienDoCongViecRepository _tienDoCongViecRepository;

        public TienDoCongViecController(ITienDoCongViecRepository tienDoCongViecRepository)
        {
            _tienDoCongViecRepository = tienDoCongViecRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTienDoCongViec(string? search, int page = 1)
        {
            var listTienDoCongViec = await _tienDoCongViecRepository.GetAllAsync(search, page);
            return Ok(listTienDoCongViec);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTienDoCongViecById(int id)
        {
            var tienDoCongViec = await _tienDoCongViecRepository.GetByIdAsync(id);
            if (tienDoCongViec == null || tienDoCongViec.MaTienDoCongViec == 0)
            {
                return NotFound();
            }
            return Ok(tienDoCongViec);
        }

        [HttpPost]
        public async Task<IActionResult> AddTienDoCongViec(TienDoCongViecViewModel model)
        {
            var tienDoCongViec = new TienDoCongViec()
            {
                MaCongViec = model.MaCongViec,
                NgayCapNhat = model.NgayCapNhat,
                MucDoHoanThanh = model.MucDoHoanThanh,
                NoiDung = model.NoiDung,
                TrangThai = model.TrangThai
            };
            var result = await _tienDoCongViecRepository.CreateAsync(tienDoCongViec);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTienDoCongViec(int id, TienDoCongViecViewModel model)
        {
            var tienDoCongViec = new TienDoCongViec()
            {
                MaCongViec = model.MaCongViec,
                NgayCapNhat = model.NgayCapNhat,
                MucDoHoanThanh = model.MucDoHoanThanh,
                NoiDung = model.NoiDung,
                TrangThai = model.TrangThai
            };
            var result = await _tienDoCongViecRepository.UpdateAsync(id, tienDoCongViec);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTienDoCongViec(int id)
        {
            int result = await _tienDoCongViecRepository.DeleteAsync(id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
