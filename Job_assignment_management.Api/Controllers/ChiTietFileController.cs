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
    public class ChiTietFileController : ControllerBase
    {
        private readonly IChiTietFileRepository _chiTietFileRepository;
        private readonly IHubContext<myHub> _hubContext;
        public ChiTietFileController(IChiTietFileRepository chiTietFileRepository, IHubContext<myHub> hubContext)
        {
            _chiTietFileRepository = chiTietFileRepository;
            _hubContext = hubContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ChiTietFileViewModel chiTietFileViewModel)
        {
            var chiTietFile = new ChiTietFile()
            {
                MaFile = chiTietFileViewModel.MaFile,
                MaPhanCong = chiTietFileViewModel.MaPhanCong,
            };
            var result = await _chiTietFileRepository.CreateAsync(chiTietFile);
            await _hubContext.Clients.All.SendAsync("loadFile");
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByFilePhanCongAsync(int id)
        {
            var listFile=await _chiTietFileRepository.GetByFilePhanCongAsync(id);
            return Ok(listFile);    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var result=await _chiTietFileRepository.DeleteAsync(id);
            await _hubContext.Clients.All.SendAsync("loadFile");
            return Ok(result);
        }
    }
}
