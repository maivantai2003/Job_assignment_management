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
    public class PhanCongController : ControllerBase
    {
        private readonly IPhanCongRepository _repository;

        public PhanCongController(IPhanCongRepository repository)
        {
            _repository = repository;
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
            //model.MaPhanCong = createdEntity.MaPhanCong;
            //return CreatedAtAction(nameof(GetPhanCongById), new { id = model.MaPhanCong }, model);
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
                //TrangThaiCongViec = model.TrangThaiCongViec,
            };

            await _repository.UpdateAsync(id, entity);
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
