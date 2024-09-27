using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MocThoiGianController : ControllerBase
    {
        private readonly IMocThoiGianRepository _mocThoiGianRepository;

        public MocThoiGianController(IMocThoiGianRepository mocThoiGianRepository)
        {
            _mocThoiGianRepository = mocThoiGianRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMocThoiGian(string? search, int page = 1)
        {
            var listMocThoiGian = await _mocThoiGianRepository.GetAllAsync(search, page);
            return Ok(listMocThoiGian);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMocThoiGianById(int id)
        {
            var mocThoiGian = await _mocThoiGianRepository.GetByIdAsync(id);
            if (mocThoiGian == null || mocThoiGian.MaMocThoiGian == 0)
            {
                return NotFound();
            }
            return Ok(mocThoiGian);
        }

        [HttpPost]
        public async Task<IActionResult> AddMocThoiGian(MocThoiGianViewModel model)
        {
            var mocThoiGian = new MocThoiGian()
            {
                MaCongViec = model.MaCongViec,
                NgayDenHan = model.NgayDenHan,
                NoiDung = model.NoiDung,
                TrangThai = model.TrangThai
            };
            var result = await _mocThoiGianRepository.CreateAsync(mocThoiGian);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMocThoiGian(int id, MocThoiGianViewModel model)
        {
            var mocThoiGian = new MocThoiGian()
            {
                MaCongViec = model.MaCongViec,
                NgayDenHan = model.NgayDenHan,
                NoiDung = model.NoiDung,
                TrangThai = model.TrangThai
            };
            var result = await _mocThoiGianRepository.UpdateAsync(id, mocThoiGian);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMocThoiGian(int id)
        {
            int result = await _mocThoiGianRepository.DeleteAsync(id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
