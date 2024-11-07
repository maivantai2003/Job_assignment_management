using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly IHubContext<myHub> _hubContext;
        public PhongBanController(IPhongBanRepository phongBanRepository, IHubContext<myHub> hubContext)
        {
            _phongBanRepository = phongBanRepository;
            _hubContext = hubContext;
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
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetTruongPhongByIdAsync(int id)
        {
            var listPhongBan = await _phongBanRepository.GetTruongPhongByIdAsync(id);
            return Ok(listPhongBan);
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
            await _hubContext.Clients.All.SendAsync("loadPhongBan");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhongBan(int id,[FromBody] PhongBanViewModel model)
        {
            var phongBan = new PhongBan
            {
                MaTruongPhong = model.MaTruongPhong,
                TenPhongBan = model.TenPhongBan
            };
            var result = await _phongBanRepository.UpdateAsync(id, phongBan);
            await _hubContext.Clients.All.SendAsync("loadPhongBan");
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
