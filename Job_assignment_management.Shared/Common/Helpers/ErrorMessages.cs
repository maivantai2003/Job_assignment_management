using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common.Helpers
{
    public static class ErrorMessages
    {
        public const string CreateFailed = "Thêm mới thất bại.";
        public const string UpdateFailed = "Cập nhật thất bại.";
        public const string DeleteFailed = "Xóa thất bại.";
        public const string FindFailed = "Tìm kiếm thất bại.";
        public const string InvalidDate = "Ngày cung cấp không hợp lệ hoặc định dạng không đúng.";
        public const string UpdateDateFailed = "Cập nhật ngày thất bại. Vui lòng kiểm tra lại định dạng ngày và thử lại.";

        public static string CreateFailedMessage(string itemName)
        {
            return $"Thêm mới '{itemName}' thất bại.";
        }

        public static string UpdateFailedMessage(string itemName)
        {
            return $"Cập nhật '{itemName}' thất bại.";
        }

        public static string DeleteFailedMessage(string itemName)
        {
            return $"Xóa '{itemName}' thất bại.";
        }

        public static string SearchFailedMessage(string searchCriteria)
        {
            return $"Tìm kiếm thất bại với tiêu chí '{searchCriteria}'.";
        }

        public static string InvalidDateMessage(string fieldName)
        {
            return $"Ngày cung cấp cho '{fieldName}' không hợp lệ hoặc định dạng không đúng.";
        }

        public static string UpdateDateFailedMessage(string fieldName)
        {
            return $"Cập nhật ngày cho '{fieldName}' thất bại. Vui lòng kiểm tra lại định dạng ngày và thử lại.";
        }

        public static string NotFoundMessage(string itemName)
        {
            return $"Không tìm thấy mục yêu cầu '{itemName}'.";
        }
    }
}
