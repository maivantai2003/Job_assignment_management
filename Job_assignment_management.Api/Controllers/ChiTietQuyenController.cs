using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Repositories;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietQuyenController : ControllerBase
    {
        private readonly IChiTietQuyenReposity _chiTietQuyenReposity;
        public ChiTietQuyenController(IChiTietQuyenReposity chiTietQuyenReposity)
        {
            _chiTietQuyenReposity = chiTietQuyenReposity;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllChiTietQuyen(string ?search,int page=1)
        {
            var listChiTietQuyen=await _chiTietQuyenReposity.GetAllAsync(search,page);
            return Ok(listChiTietQuyen);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChiTietQuyenById(int id)
        {
            var chiTietQuyen=await _chiTietQuyenReposity.GetByIdAsync(id);
            return Ok(chiTietQuyen);
        }
        [HttpPost]
        public async Task<IActionResult> AddChiTietQuyen(ChiTietQuyenViewModel model)
        {
            var chiTietQuyen = new ChiTietQuyen()
            {
                MaChucNang = model.MaChucNang,
                MaNhomQuyen = model.MaNhomQuyen,
            };
            var result=await _chiTietQuyenReposity.CreateAsync(chiTietQuyen);   
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChiTietQuyen(int id,ChiTietQuyenViewModel model)
        {
            var chiTietQuyen = new ChiTietQuyen()
            {
                MaChucNang = model.MaChucNang,
                MaNhomQuyen = model.MaNhomQuyen,
            };
            var ChiTietQuyen = await _chiTietQuyenReposity.UpdateAsync(id,chiTietQuyen);
            return Ok(ChiTietQuyen);    
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietQuyen(int id)
        {
            int maChiTietQuyen = await _chiTietQuyenReposity.DeleteAsync(id);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(maChiTietQuyen);
        }
    }
}
