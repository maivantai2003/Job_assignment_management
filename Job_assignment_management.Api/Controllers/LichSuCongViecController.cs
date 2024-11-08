using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LichSuCongViecController : ControllerBase
    {
        private readonly ILichSuCongViecRepository _lichSuCongViecRepository;
        private readonly IHubContext<myHub> _hubContext;

        public LichSuCongViecController(ILichSuCongViecRepository tienDoCongViecRepository, IHubContext<myHub> hubContext)
        {
            _lichSuCongViecRepository = tienDoCongViecRepository;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLichSuCongViec()
        {
            var listTienDoCongViec = await _lichSuCongViecRepository.GetAllAsync();
            return Ok(listTienDoCongViec);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLichSuCongViecById(int id)
        {
            var tienDoCongViec = await _lichSuCongViecRepository.GetByIdAsync(id);
            return Ok(tienDoCongViec);
        }

        [HttpPost]
        public async Task<IActionResult> AddLichSuCongViec(LichSuCongViecViewModel model)
        {
            var tienDoCongViec = new LichSuCongViec()
            {
                MaCongViec = model.MaCongViec,
                NgayCapNhat = model.NgayCapNhat,
                NoiDung = model.NoiDung
            };
            var result = await _lichSuCongViecRepository.CreateAsync(tienDoCongViec);
            //await _hubContext.Clients.All.SendAsync("loadLichSuCongViec");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLichSuCongViec(int id, LichSuCongViecViewModel model)
        {
            var tienDoCongViec = new LichSuCongViec()
            {
                MaCongViec = model.MaCongViec,
                NgayCapNhat = model.NgayCapNhat,
                NoiDung = model.NoiDung
            };
            var result = await _lichSuCongViecRepository.UpdateAsync(id, tienDoCongViec);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTienDoCongViec(int id)
        {
            int result = await _lichSuCongViecRepository.DeleteAsync(id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
