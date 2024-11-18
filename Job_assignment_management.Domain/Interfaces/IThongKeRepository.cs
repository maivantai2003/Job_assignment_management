using Job_assignment_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Domain.Interfaces
{
    public interface IThongKeRepository
    {
        public Task<List<ThongKeNhanVien>> ThongKeNhanVien(DateTime thoiGianBatDau,DateTime thoiGianKetThuc,string? trangThai);
        public Task<List<ThongKePhongBan>> ThongKePhongBan(DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string? trangThai);
        public Task<ThongKeNhanVien> NhanVien(int maNhanVien, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string? trangThai);
        public Task<ThongKePhongBan> PhongBan(int maPhongBan, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string? trangThai);
    }
}
