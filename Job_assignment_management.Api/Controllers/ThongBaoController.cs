using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job_assignment_management.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ThongBaoController:ControllerBase
{
    private readonly IThongBaoRepository thongBaoRepository;

    public ThongBaoController(IThongBaoRepository thongBaoRepository)
    {
        this.thongBaoRepository = thongBaoRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateThongBao(ThongBaoModel thongBaoModel)
    {
        var thongBao = new ThongBao();
        thongBao.MaNhanVien = thongBaoModel.MaNhanVien;
        thongBao.MaCongViec = thongBaoModel.MaCongViec;
        thongBao.NgayGui = thongBaoModel.NgayGui;
        thongBao.NoiDungThongBao = thongBaoModel.NoiDungThongBao;
        thongBao.TrangThai = thongBaoModel.TrangThai;

        var result = await thongBaoRepository.CreateAsync(thongBao);
        return Ok(result);
    }
}