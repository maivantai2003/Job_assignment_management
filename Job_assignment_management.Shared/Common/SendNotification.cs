using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Shared.Common
{
    public class SendNotification
    {
        public int MaCongViec {  get; set; }
        public string? TenCongViec {  set; get; }
        public string? NoiDung {  get; set; }   
        public DateTime? ThoiGianKetThuc { get; set; }
        public string? Email {  get; set; }
    }
}
