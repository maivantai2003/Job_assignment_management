using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Infrastructure.Repositories
{
    public class ThongKeRepository : IThongKeRepository
    {
        private readonly ApplicationDbContext _context;
        public ThongKeRepository(ApplicationDbContext context) { _context = context; }
        public async Task<List<CongViec>> ThongKeCongViec()
        {
            return await _context.congViecs.AsNoTracking().Where(x => x.TrangThai == true).ToListAsync();
        }

        public async Task<List<ThongKeNhanVien>> ThongKeNhanVien()
        {
            var phanCongs = await _context.phanCongs.Where(x=>x.TrangThai==true)
                .GroupBy(pc => pc.MaNhanVien)
                .Select(g => new
                {
                    MaNhanVien = g.Key,
                    PhanCongHoanThanh = g.Count(pc => pc.TrangThaiCongViec),
                    PhanCongChuaHoanhThanh = g.Count(pc => !pc.TrangThaiCongViec),
                    TotalPhanCong = g.Count()
                })
                .ToListAsync();
            var nhanViens = await _context.nhanViens
                .AsNoTracking()
                .ToListAsync();
            var result = nhanViens.Select(nv =>
            {
                var phanCong = phanCongs.FirstOrDefault(pc => pc.MaNhanVien == nv.MaNhanVien);
                var phanTramPhanCong = phanCong != null && phanCong.TotalPhanCong > 0
                    ? (double)phanCong.PhanCongHoanThanh / phanCong.TotalPhanCong * 100
                    : 0;

                return new ThongKeNhanVien
                {
                    MaNhanVien = nv.MaNhanVien,
                    TenNhanVien = nv.TenNhanVien,
                    PhanCongHoanThanh = phanCong?.PhanCongHoanThanh ?? 0,
                    PhanCongChuaHoanhThanh = phanCong?.PhanCongChuaHoanhThanh ?? 0,
                    PhanTramPhanCong = phanTramPhanCong
                };
            }).ToList();

            return result;
        }

        public async Task<List<ThongKePhongBan>> ThongKePhongBan()
        {
            var result = await _context.congViecPhongBans
                .GroupBy(cvp => cvp.MaPhongBan)
                .Select(g => new
                {
                    MaPhongBan = g.Key,
                    PhongBan = g.Select(cvp => cvp.PhongBan).FirstOrDefault(),
                    PhanCongHoanThanh = g.Count(cvp => cvp.CongViec.TrangThaiCongViec),
                    PhanCongChuaHoanThanh = g.Count(cvp => !cvp.CongViec.TrangThaiCongViec),
                    TotalCongViec = g.Count()
                })
                .ToListAsync();
            var thongKePhongBanList = result.Select(item => new ThongKePhongBan
            {
                MaPhongBan = item.MaPhongBan,
                TenPhongBan = item.PhongBan?.TenPhongBan,
                PhanCongHoanThanh = item.PhanCongHoanThanh,
                PhanCongChuaHoanhThanh = item.PhanCongChuaHoanThanh,
                PhanTramPhanCong = item.TotalCongViec > 0 ? (double)item.PhanCongHoanThanh / item.TotalCongViec * 100 : 0
            }).ToList();

            return thongKePhongBanList;
        }
    }
}
