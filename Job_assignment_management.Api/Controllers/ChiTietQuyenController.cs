using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
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
    public class ChiTietQuyenController : ControllerBase
    {
        private readonly IChiTietQuyenReposity _chiTietQuyenReposity;
        private readonly IChucNangRepository _chucNangRepository;
        private readonly IHubContext<myHub> _hubContext;
        public ChiTietQuyenController(IChiTietQuyenReposity chiTietQuyenReposity, IChucNangRepository chucNangRepository, IHubContext<myHub> hubContext)
        {
            _chiTietQuyenReposity = chiTietQuyenReposity;
            _chucNangRepository = chucNangRepository;
            _hubContext = hubContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllChiTietQuyen()
        {
            var listChiTietQuyen=await _chiTietQuyenReposity.GetAllAsync();
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
                HanhDong=model.HanhDong,
            };
            var result=await _chiTietQuyenReposity.CreateAsync(chiTietQuyen);
            await _hubContext.Clients.All.SendAsync("loadHanhDong");
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> KiemTraQuyen(ChiTietChucNangQuyenViewModel chiTietChucNangQuyen)
        {
            var tmp = await _chucNangRepository.GetFunctionAsync(chiTietChucNangQuyen.tenChucNang);
            if(tmp== null)
            {
                return Ok(new List<string>());
            }
            var chiTietQuyen = new ChiTietQuyen()
            {
                MaChucNang = tmp.MaChucNang,
                MaNhomQuyen = chiTietChucNangQuyen.MaQuyen,
                HanhDong = chiTietChucNangQuyen.HanhDong
            };
            var result=await _chiTietQuyenReposity.CheckQuyenAsync(chiTietQuyen);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChiTietQuyen(int id,ChiTietQuyenViewModel model)
        {
            var chiTietQuyen = new ChiTietQuyen()
            {
                MaChucNang = model.MaChucNang,
                MaNhomQuyen = model.MaNhomQuyen,
                HanhDong = model.HanhDong,
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
            await _hubContext.Clients.All.SendAsync("loadHanhDong");
            return Ok(maChiTietQuyen);
        }
    }
}
