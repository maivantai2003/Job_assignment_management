using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Infrastructure.Repositories;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomQuyenController : ControllerBase
    {
        private readonly INhomQuyenRepository _nhomQuyenRepository;
        public NhomQuyenController(INhomQuyenRepository nhomQuyenRepository)
        {
            _nhomQuyenRepository = nhomQuyenRepository;
        }
        [HttpPost("AddNhomQuyen")]
        public async Task<IActionResult> AddNhomQuyen(NhomQuyenViewModel nhomQuyenVM)
        {
            var nhomQuyen=new NhomQuyen()
            {
                TenQuyen=nhomQuyenVM.TenQuyen,
            };
            var create = await _nhomQuyenRepository.CreateAsync(nhomQuyen);
            return Ok(create);
        }
        [HttpGet("GetAllNhomQuyen")]
        public async Task<ActionResult> GetAllNhomQuyen(string ?search,int page=1)
        {
            var nhomQuyen = await _nhomQuyenRepository.GetAllAsync(search, page);
            return Ok(nhomQuyen);
        }
        [HttpGet("GetNhomQuyenById/{id}")]
        public async Task<ActionResult> GetNhomQuyenById(int id)
        {
            var nhomQuyen = await _nhomQuyenRepository.GetByIdAsync(id);
            return Ok(nhomQuyen);
        }
        [HttpPut("UpdateNhomQuyen/{id}")]
        public async Task<IActionResult> UpdateNhomQuyen(int id,NhomQuyenViewModel nhomQuyenVM)
        {
            var nhomQuyen = new NhomQuyen()
            {
                TenQuyen = nhomQuyenVM.TenQuyen,
            };
            var update=await _nhomQuyenRepository.UpdateAsync(id, nhomQuyen);
            return NoContent();
        }
        [HttpDelete("DeleteNhomQuyen/{id}")]
        public async Task<IActionResult> DeleteNhomQuyen(int id) { 
            int maQuyen=await _nhomQuyenRepository.DeleteAsync(id);
            if (id==0)
            {
                return BadRequest();
            }
            return Ok(maQuyen);
        }
    }
}
