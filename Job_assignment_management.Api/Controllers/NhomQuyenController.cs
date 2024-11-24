using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Infrastructure.Repositories;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class NhomQuyenController : ControllerBase
    {
        private readonly INhomQuyenRepository _nhomQuyenRepository;
        private readonly IHubContext<myHub> _hubContext;
        public NhomQuyenController(INhomQuyenRepository nhomQuyenRepository, IHubContext<myHub> hubContext)
        {
            _nhomQuyenRepository = nhomQuyenRepository;
            _hubContext = hubContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddNhomQuyen(NhomQuyenViewModel nhomQuyenVM)
        {
            var nhomQuyen=new NhomQuyen()
            {
                TenQuyen=nhomQuyenVM.TenQuyen,
            };
            var create = await _nhomQuyenRepository.CreateAsync(nhomQuyen);
            await _hubContext.Clients.All.SendAsync("loadNhomQuyen");
            return Ok(create);
        }
        /*[HttpGet]
        public async Task<ActionResult> GetAllNhomQuyen()
        {
            return Ok(await _nhomQuyenRepository.GetAllAsync());
        }*/
        [HttpGet]
        public async Task<ActionResult> GetAllNhomQuyen(string ?search,int page=1)
        {
            var nhomQuyen = await _nhomQuyenRepository.GetAllAsync(search, page);
            return Ok(nhomQuyen);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetNhomQuyenById(int id)
        {
            var nhomQuyen = await _nhomQuyenRepository.GetByIdAsync(id);
            return Ok(nhomQuyen);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhomQuyen(int id,NhomQuyenViewModel nhomQuyenVM)
        {
            var nhomQuyen = new NhomQuyen()
            {
                TenQuyen = nhomQuyenVM.TenQuyen,
            };
            var update=await _nhomQuyenRepository.UpdateAsync(id, nhomQuyen);
            return NoContent();
        }
        [HttpDelete("{id}")]
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
