using Job_assignment_management.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeController : ControllerBase
    {
        private readonly IThongKeRepository _thongKeRepository;
        public ThongKeController(IThongKeRepository thongKeRepository)
        {
            _thongKeRepository = thongKeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ThongKeCongViec()
        {
            return Ok(await _thongKeRepository.ThongKeCongViec());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ThongKeNhanVien()
        {
            return Ok(await _thongKeRepository.ThongKeNhanVien()); 
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ThongKePhongBan()
        {
            return Ok(await _thongKeRepository.ThongKePhongBan());
        }
    }
}
