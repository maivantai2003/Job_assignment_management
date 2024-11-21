using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")] // Định tuyến cho API, sử dụng tên controller
    [ApiController] // Đánh dấu lớp là một API Controller
    [Authorize] // Yêu cầu xác thực cho tất cả các hành động trong controller này
    public class TraoDoiThongTinController : ControllerBase
    {
        private readonly ITraoDoiThongTinRepository _traoDoiThongTinRepository;

        // Constructor của Controller, inject các dependencies
        public TraoDoiThongTinController(ITraoDoiThongTinRepository traoDoiThongTinRepository)
        {
            _traoDoiThongTinRepository = traoDoiThongTinRepository; // Repository để làm việc với dữ liệu trao đổi thông tin
        }

        // API GET: Lấy tất cả các trao đổi thông tin với các tùy chọn tìm kiếm và phân trang
        [HttpGet]
        public async Task<IActionResult> GetAllTraoDoiThongTin(string? search, int page = 1)
        {
            var listTraoDoiThongTin = await _traoDoiThongTinRepository.GetAllAsync(search, page); // Lấy tất cả trao đổi thông tin
            return Ok(listTraoDoiThongTin); // Trả về kết quả OK cùng dữ liệu
        }

        // API GET: Lấy trao đổi thông tin theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTraoDoiThongTin(int id)
        {
            var traoDoiThongTin = await _traoDoiThongTinRepository.GetByIdAsync(id); // Lấy trao đổi thông tin theo ID
            return Ok(traoDoiThongTin); // Trả về kết quả OK cùng dữ liệu
        }

        // API POST: Tạo mới trao đổi thông tin
        [HttpPost]
        public async Task<IActionResult> CreateTraoDoiThongTin(TraoDoiThongTinViewModel model)
        {
            // Tạo đối tượng TraoDoiThongTin từ ViewModel
            var traoDoiThongTin = new TraoDoiThongTin()
            {
                NoiDungTraoDoi = model.NoiDungTraoDoi,
                MaCongViec = model.MaCongViec,
                MaNhanVien = model.MaNhanVien
            };
            var res = await _traoDoiThongTinRepository.CreateAsync(traoDoiThongTin); // Tạo mới trao đổi thông tin
            return Ok(res); // Trả về kết quả OK cùng dữ liệu
        }

        // API PUT: Cập nhật trao đổi thông tin theo ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraoDoiThongTin(int id, TraoDoiThongTinViewModel model)
        {
            // Tạo đối tượng TraoDoiThongTin từ ViewModel
            var traoDoiThongTin = new TraoDoiThongTin()
            {
                NoiDungTraoDoi = model.NoiDungTraoDoi,
                MaCongViec = model.MaCongViec,
                MaNhanVien = model.MaNhanVien
            };
            var result = await _traoDoiThongTinRepository.UpdateAsync(id, traoDoiThongTin); // Cập nhật trao đổi thông tin
            return Ok(result); // Trả về kết quả OK cùng dữ liệu
        }

        // API DELETE: Xóa trao đổi thông tin theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraoDoiThongTin(int id)
        {
            int result = await _traoDoiThongTinRepository.DeleteAsync(id); // Xóa trao đổi thông tin theo ID
            if (result == 0)
            {
                return BadRequest(); // Trả về BadRequest nếu không tìm thấy trao đổi thông tin để xóa
            }
            return Ok(result); // Trả về kết quả OK cùng dữ liệu
        }
    }
}

