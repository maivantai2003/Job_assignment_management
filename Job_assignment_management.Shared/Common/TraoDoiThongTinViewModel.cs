using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Mục đích:
//Lớp này thường được sử dụng trong giao tiếp giữa client (frontend) và server (backend), thường ở dạng ViewModel trong ASP.NET Core MVC hoặc API.
//Nó giúp đảm bảo rằng dữ liệu truyền tải phù hợp với các quy định (như các trường bắt buộc phải có dữ liệu).
//Vai trò:
//Lấy dữ liệu từ người dùng: Gửi từ client đến server khi người dùng nhập thông tin.
//Xác thực dữ liệu: Các thuộc tính [Required] giúp đảm bảo dữ liệu được cung cấp đầy đủ, tránh lỗi khi xử lý dữ liệu trên server.
//Truyền dữ liệu đến giao diện người dùng: Dữ liệu có thể được sử dụng để hiển thị hoặc xử lý thông tin trao đổi giữa nhân viên và công việc.
namespace Job_assignment_management.Shared.Common
{
    public class TraoDoiThongTinViewModel
    {
        [Required]
        public int MaCongViec { get; set; }

        [Required]
        public int MaNhanVien { get; set; }
        public string? NoiDungTraoDoi { get; set; }
    }
}
