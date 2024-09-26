using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanRepository _phongBanRepository;

        public PhongBanController(IPhongBanRepository phongBanRepository)
        {
            _phongBanRepository = phongBanRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPhongBan(string? search, int page = 1)
        {
            var listPhongBan = await _phongBanRepository.GetAllAsync(search, page);
            return Ok(listPhongBan);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhongBanById(int id)
        {
            var phongBan = await _phongBanRepository.GetByIdAsync(id);
            return Ok(phongBan);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePhongBan(PhongBanViewModel model)
        {
            var phongBan = new PhongBan
            {
                MaTruongPhong = model.MaTruongPhong,
                TenPhongBan = model.TenPhongBan
            };
            var result = await _phongBanRepository.CreateAsync(phongBan);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhongBan(int id, PhongBanViewModel model)
        {
            var phongBan = new PhongBan
            {
                MaTruongPhong = model.MaTruongPhong,
                TenPhongBan = model.TenPhongBan
            };
            var result = await _phongBanRepository.UpdateAsync(id, phongBan);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhongBan(int id)
        {
            var result = await _phongBanRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
