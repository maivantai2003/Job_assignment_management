using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenGiaoCongViecController : ControllerBase
    {
        private readonly IChuyenGiaoCongViecRepository _repository;

        public ChuyenGiaoCongViecController(IChuyenGiaoCongViecRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChuyenGiaoCongViec(string? search, int page = 1)
        {
            var list = await _repository.GetAllAsync(search, page);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChuyenGiaoCongViecById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChuyenGiaoCongViec(ChuyenGiaoCongViecViewModel model)
        {
            var entity = new ChuyenGiaoCongViec
            {
                LyDoChuyenGiao = model.LyDoChuyenGiao,
                MaNhanVienChuyenGiao = model.MaNhanVienChuyenGiao,
                MaNhanVienThucHien = model.MaNhanVienThucHien,
                MaPhanCong = model.MaPhanCong,
                NgayChuyenGiao = model.NgayChuyenGiao
            };

            var createdEntity = await _repository.CreateAsync(entity);
            model.MaChuyenGiaoCongViec = createdEntity.MaChuyenGiaoCongViec;
            return CreatedAtAction(nameof(GetChuyenGiaoCongViecById), new { id = model.MaChuyenGiaoCongViec }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChuyenGiaoCongViec(int id, ChuyenGiaoCongViecViewModel model)
        {
            var entity = new ChuyenGiaoCongViec
            {
                MaChuyenGiaoCongViec = id,
                LyDoChuyenGiao = model.LyDoChuyenGiao,
                MaNhanVienChuyenGiao = model.MaNhanVienChuyenGiao,
                MaNhanVienThucHien = model.MaNhanVienThucHien,
                MaPhanCong = model.MaPhanCong,
                NgayChuyenGiao = model.NgayChuyenGiao
            };

            await _repository.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChuyenGiaoCongViec(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
