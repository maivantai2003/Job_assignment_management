using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NhacNhoController : ControllerBase
    {
        private readonly INhacNhoRepository _nhacNhoRepository;

        public NhacNhoController(INhacNhoRepository nhacNhoRepository)
        {
            _nhacNhoRepository = nhacNhoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _nhacNhoRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NhacNhoViewModel nhacNhoViewModel)
        {
            var nhacNho = new NhacNho
            {
                MaCongViec = nhacNhoViewModel.MaCongViec,
                NoiDungNhacNho = nhacNhoViewModel.NoiDungNhacNho
            };
            var result = await _nhacNhoRepository.CreateAsync(nhacNho);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _nhacNhoRepository.DeleteByIdAsync(id);
            if (result == -1) return NotFound();
            return Ok(result);
        }
    }
}
