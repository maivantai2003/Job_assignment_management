using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuAnController : ControllerBase
    {
        private readonly IDuAnRepository _duAnRepository;

        public DuAnController(IDuAnRepository duAnRepository)
        {
            _duAnRepository = duAnRepository;
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
            var duAn = await _duAnRepository.GetByIdAsync(id);
            return Ok(duAn);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDuAn(DuAnViewModel model)
        {
            var duAn = new DuAn
            {
                TenDuAn = model.TenDuAn
            };
            var result = await _duAnRepository.CreateAsync(duAn);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDuAn(int id, DuAnViewModel model)
        {
            var duAn = new DuAn
            {
                TenDuAn = model.TenDuAn
            };
            var result = await _duAnRepository.UpdateAsync(id, duAn);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuAn(int id)
        {
            var result = await _duAnRepository.DeleteAsync(id);
            return Ok(result);
        }

    }
}
