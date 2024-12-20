﻿using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChuyenGiaoCongViecController : ControllerBase
    {
        private readonly IChuyenGiaoCongViecRepository _repository;
        private readonly IHubContext<myHub> _hubContext; 
        public ChuyenGiaoCongViecController(IChuyenGiaoCongViecRepository repository,IHubContext<myHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChuyenGiaoCongViec(string? search, int page = 1)
        {
            var list = await _repository.GetAllAsync(search, page);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChuyenGiaoCongViecById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChuyenGiaoCongViec(ChuyenGiaoCongViecViewModel model)
        {
            var entity = new ChuyenGiaoCongViec
            {
                LyDoChuyenGiao = model.LyDoChuyenGiao,
                MaNhanVienChuyenGiao = model.MaNhanVienChuyenGiao,
                MaNhanVienThucHien = model.MaNhanVienThucHien,
                MaPhanCong = model.MaPhanCong,
                VaiTro=model.VaiTro,
                TenCongViec = model.TenCongViec
            };

            var createdEntity = await _repository.CreateAsync(entity);
            if (model.MaNhanVienThucHien==null)
            {
                await _hubContext.Clients.All.SendAsync("loadPhanCong");
                await _hubContext.Clients.All.SendAsync("loadCongViec");
            }
            return CreatedAtAction(nameof(GetChuyenGiaoCongViecById), new { id = createdEntity.MaChuyenGiaoCongViec }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChuyenGiaoCongViec(int id, ChuyenGiaoCongViecViewModel model)
        {
            var entity = new ChuyenGiaoCongViec
            {
                MaChuyenGiaoCongViec = id,
                LyDoChuyenGiao = model.LyDoChuyenGiao,
                MaNhanVienChuyenGiao = model.MaNhanVienChuyenGiao,
                MaNhanVienThucHien = model.MaNhanVienThucHien,
                MaPhanCong = model.MaPhanCong,
                VaiTro = model.VaiTro
            };

            await _repository.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChuyenGiaoCongViec(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
