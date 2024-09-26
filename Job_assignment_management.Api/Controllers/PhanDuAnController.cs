using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanDuAnController : ControllerBase
    {
        private readonly IPhanDuAnRepository _phanDuAnRepository;

        public PhanDuAnController(IPhanDuAnRepository phanDuAnRepository)
        {
            _phanDuAnRepository = phanDuAnRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPhanDuAn(string? search, int page = 1)
        {
            var listPhanDuAn = await _phanDuAnRepository.GetAllAsync(search, page);
            return Ok(listPhanDuAn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhanDuAnById(int id)
        {
            var phanDuAn = await _phanDuAnRepository.GetByIdAsync(id);
            return Ok(phanDuAn);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePhanDuAn(PhanDuAnViewModel model)
        {
            var phanDuAn = new PhanDuAn
            {
                MaDuAn = model.MaDuAn,
                TenPhan = model.TenPhan
            };
            var result = await _phanDuAnRepository.CreateAsync(phanDuAn);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhanDuAn(int id, PhanDuAnViewModel model)
        {
            var phanDuAn = new PhanDuAn
            {
                TenPhan = model.TenPhan
            };
            var result = await _phanDuAnRepository.UpdateAsync(id, phanDuAn);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhanDuAn(int id)
        {
            var result = await _phanDuAnRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
