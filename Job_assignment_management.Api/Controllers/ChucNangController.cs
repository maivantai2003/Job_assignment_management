using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucNangController : ControllerBase
    {
        private IChucNangRepository _chucNangRepository;
        public ChucNangController(IChucNangRepository chucNangRepository)
        {
            _chucNangRepository = chucNangRepository;
        }
        [HttpGet("GetAllChucNang")]
        public async Task<IActionResult> GetAllChucNang(string ?search,int page=1)
        {
            var listChucNang=await _chucNangRepository.GetAllAsync(search,page);
            return Ok(listChucNang);
        }
        [HttpPost("AddChucNang")]
        public async Task<IActionResult> CreateChucNang(ChucNangViewModel model)
        {
            var chucNang = new ChucNang()
            {
                TenChucNang = model.TenChucNang,
            };
            var result = await _chucNangRepository.CreateAsync(chucNang);
            return Ok(model);
        }
        [HttpGet("GetChucNangById/{id}")]
        public async Task<ActionResult> GetChucNangById(int id)
        {
            var chucNang = await _chucNangRepository.GetByIdAsync(id);
            return Ok(chucNang);
        }
        [HttpPut("UpdateChucNang/{id}")]
        public async Task<IActionResult> UpdateChucNang(int id,ChucNangViewModel chucNangVM)
        {
            var chucNang = new ChucNang()
            {
                TenChucNang = chucNangVM.TenChucNang
            };
            var update = await _chucNangRepository.UpdateAsync(id, chucNang);
            return NoContent();
        }
        [HttpDelete("DeleteChucNang/{id}")]
        public async Task<IActionResult> DeleteChucNang(int id)
        {
            int maChucNang = await _chucNangRepository.DeleteAsync(id);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(maChucNang);
        }
    }
}
