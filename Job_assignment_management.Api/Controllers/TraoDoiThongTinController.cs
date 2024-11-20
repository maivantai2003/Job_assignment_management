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
    public class TraoDoiThongTinController : ControllerBase
    {
        private readonly ITraoDoiThongTinRepository _traoDoiThongTinRepository;

        public TraoDoiThongTinController(ITraoDoiThongTinRepository traoDoiThongTinRepository)
        {
            _traoDoiThongTinRepository = traoDoiThongTinRepository;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAll(int id) {
            return Ok(await _traoDoiThongTinRepository.GetAllAsync(id));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTraoDoiThongTin(int id)
        {
            return Ok(await _traoDoiThongTinRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTraoDoiThongTin(TraoDoiThongTinViewModel model)
        {
            var traoDoiThongTin = new TraoDoiThongTin()
            {
                NoiDungTraoDoi = model.NoiDungTraoDoi,
                MaCongViec = model.MaCongViec,
                MaNhanVien = model.MaNhanVien,
                TenNhanVien=model.TenNhanVien
            };
            var res = await _traoDoiThongTinRepository.CreateAsync(traoDoiThongTin);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraoDoiThongTin(int id, TraoDoiThongTinViewModel model)
        {
            var traoDoiThongTin = new TraoDoiThongTin()
            {
                NoiDungTraoDoi = model.NoiDungTraoDoi,
                MaCongViec = model.MaCongViec,
                MaNhanVien = model.MaNhanVien
            };
            var ChiTietQuyen = await _traoDoiThongTinRepository.UpdateAsync(id, traoDoiThongTin);
            return Ok(ChiTietQuyen);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraoDoiThongTin(int id)
        {
            int maTraoDoiTT = await _traoDoiThongTinRepository.DeleteAsync(id);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(maTraoDoiTT);
        }
    }
}
