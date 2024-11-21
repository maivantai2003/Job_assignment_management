using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")] // Định tuyến cho API, sử dụng tên controller
    [ApiController] // Đánh dấu lớp là một API Controller
    //[Authorize] // Chú thích để yêu cầu xác thực, hiện tại đang bị chú thích
    public class LichSuCongViecController : ControllerBase
    {
        private readonly ILichSuCongViecRepository _lichSuCongViecRepository;
        private readonly IHubContext<myHub> _hubContext;

        // Constructor của Controller, inject các dependencies
        public LichSuCongViecController(ILichSuCongViecRepository tienDoCongViecRepository, IHubContext<myHub> hubContext)
        {
            _lichSuCongViecRepository = tienDoCongViecRepository; // Repository để làm việc với dữ liệu lịch sử công việc
            _hubContext = hubContext; // Hub context để gửi thông báo qua SignalR
        }

        // API GET: Lấy toàn bộ lịch sử công việc
        [HttpGet]
        public async Task<IActionResult> GetAllLichSuCongViec()
        {
            var listTienDoCongViec = await _lichSuCongViecRepository.GetAllAsync(); // Lấy tất cả lịch sử công việc
            return Ok(listTienDoCongViec); // Trả về kết quả OK cùng dữ liệu
        }

        // API GET: Lấy lịch sử công việc theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLichSuCongViecById(int id)
        {
            var tienDoCongViec = await _lichSuCongViecRepository.GetByIdAsync(id); // Lấy lịch sử công việc theo ID
            return Ok(tienDoCongViec); // Trả về kết quả OK cùng dữ liệu
        }

        // API POST: Thêm mới lịch sử công việc
        [HttpPost]
        public async Task<IActionResult> AddLichSuCongViec(LichSuCongViecViewModel model)
        {
            // Tạo đối tượng LichSuCongViec từ ViewModel
            var tienDoCongViec = new LichSuCongViec()
            {
                MaCongViec = model.MaCongViec,
                NgayCapNhat = model.NgayCapNhat,
                NoiDung = model.NoiDung
            };
            var result = await _lichSuCongViecRepository.CreateAsync(tienDoCongViec); // Thêm mới lịch sử công việc
            await _hubContext.Clients.All.SendAsync("loadLichSuCongViec"); // Gửi thông báo qua SignalR tới tất cả các client
            return Ok(result); // Trả về kết quả OK cùng dữ liệu
        }

        // API PUT: Cập nhật lịch sử công việc theo ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLichSuCongViec(int id, LichSuCongViecViewModel model)
        {
            // Tạo đối tượng LichSuCongViec từ ViewModel
            var tienDoCongViec = new LichSuCongViec()
            {
                MaCongViec = model.MaCongViec,
                NgayCapNhat = model.NgayCapNhat,
                NoiDung = model.NoiDung
            };
            var result = await _lichSuCongViecRepository.UpdateAsync(id, tienDoCongViec); // Cập nhật lịch sử công việc
            if (result == 0)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy lịch sử công việc để cập nhật
            }
            return Ok(result); // Trả về kết quả OK cùng dữ liệu
        }

        // API DELETE: Xóa lịch sử công việc theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTienDoCongViec(int id)
        {
            int result = await _lichSuCongViecRepository.DeleteAsync(id); // Xóa lịch sử công việc theo ID
            if (result == 0)
            {
                return BadRequest(); // Trả về BadRequest nếu không tìm thấy lịch sử công việc để xóa
            }
            return Ok(result); // Trả về kết quả OK cùng dữ liệu
        }
    }
}
