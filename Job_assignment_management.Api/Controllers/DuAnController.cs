using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Job_assignment_management.Shared.Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DuAnController : ControllerBase
    {
        private readonly IDuAnRepository _duAnRepository;
        private readonly IHubContext<myHub> _hubContext;    

        public DuAnController(IDuAnRepository duAnRepository, IHubContext<myHub> hubContext)
        {
            _duAnRepository = duAnRepository;
            _hubContext = hubContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDuAn(string? search, int page = 1)
        {
            var listDuAn = await _duAnRepository.GetAllAsync(search, page);
            return Ok(listDuAn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDuAnById(int id)
        {
            try
            {
                var duAn = await _duAnRepository.GetByIdAsync(id);
                return Ok(duAn);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error = ErrorMessages.FindFailed
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDuAn(DuAnViewModel model)
        {
            try
            {
                var duAn = new DuAn
                {
                    TenDuAn = model.TenDuAn
                };
                var result = await _duAnRepository.CreateAsync(duAn);
                await _hubContext.Clients.All.SendAsync("loadDuAn");
                return Ok(result);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error = ErrorMessages.CreateFailed
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDuAn(int id, DuAnViewModel model)
        {
            try
            {
                var duAn = new DuAn
                {
                    TenDuAn = model.TenDuAn
                };
                var result = await _duAnRepository.UpdateAsync(id, duAn);
                return NoContent();
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error = ErrorMessages.UpdateFailed
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuAn(int id)
        {
            var result = await _duAnRepository.DeleteAsync(id);
            return Ok(result);
        }

    }
}
