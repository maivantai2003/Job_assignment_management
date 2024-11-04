using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CongViecPhongBanController : ControllerBase
    {
        private readonly ICongViecPhongBanRepository _congViecPhongBanRepository;
        public CongViecPhongBanController(ICongViecPhongBanRepository congViecPhongBanRepository)
        {
            _congViecPhongBanRepository = congViecPhongBanRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCongViecPhongBan(string? search, int page = 1)
        {
            var listCongViecPhongBan = await _congViecPhongBanRepository.GetAllAsync(search, page);
            return Ok(listCongViecPhongBan);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCongViecPhongBanById(int id)
        {
            var congViecPhongBan = await _congViecPhongBanRepository.GetByIdAsync(id);
            return Ok(congViecPhongBan);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPhongBanPhanCong(int id)
        {
            return Ok(await _congViecPhongBanRepository.GetPhongBanPhanCongAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCongViecPhongBan(CongViecPhongBanViewModel model)
        {
            var congViecPhongBan = new CongViecPhongBan()
            {
                MaPhongBan = model.MaPhongBan,
                MaCongViec = model.MaCongViec,
            };
            var result = await _congViecPhongBanRepository.CreateAsync(congViecPhongBan);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCongViecPhongBan(int id, CongViecPhongBanViewModel model)
        {
            var congViecPhongBan = new CongViecPhongBan()
            {
                MaPhongBan = model.MaPhongBan,
                MaCongViec = model.MaCongViec,
            };
            var result = await _congViecPhongBanRepository.UpdateAsync(id, congViecPhongBan);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongViecPhongBan(int id)
        {
            int maCongViecPhongBan = await _congViecPhongBanRepository.DeleteAsync(id);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(maCongViecPhongBan);
        }
    }
}
