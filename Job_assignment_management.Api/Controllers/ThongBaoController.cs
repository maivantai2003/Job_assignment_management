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
        thongBao.NoiDungThongBao = thongBaoModel.NoiDungThongBao;
        
        //business logic checking
        if (thongBao.NoiDungThongBao == "")
        {
            return BadRequest("NoiDungThongBao can not be blank");
        }

        var result = await thongBaoRepository.CreateAsync(thongBao);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetThongBao(int id)
    {
        var result = await thongBaoRepository.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound("No Notifications Found");
        }
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateThongBao(int id, ThongBaoModel thongBaoModel)
    {
        var thongBao = new ThongBao();
        thongBao.NoiDungThongBao = thongBaoModel.NoiDungThongBao;
        thongBao.TrangThai = thongBaoModel.TrangThai;
        
        //business logic checking
        if (thongBao.NoiDungThongBao == "")
        {
            return BadRequest("NoiDungThongBao can not be blank");
        }

        try
        {
            var result = await thongBaoRepository.UpdateAsync(id ,thongBao);
            return Ok(result);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteThongBao(int id)
    {
        try
        {
            var result = await thongBaoRepository.DeleteAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    private void PagingProcess(ref int page, ref int limit)
    {
        if (page <= 0)
        {
            page = 1;
        }

        if (limit <= 0)
        {
            limit = 10;
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllThongBaoByCongViec()
    {
        int.TryParse(HttpContext.Request.Query["ma_cong_viec"], out int maCongViec);
        int.TryParse(HttpContext.Request.Query["page"], out int page);
        int.TryParse(HttpContext.Request.Query["limit"], out int limit);
        PagingProcess(ref page, ref limit);
        var result = await thongBaoRepository.GetAllAsync(maCongViec, page, limit);
        return Ok(result);
    }
}