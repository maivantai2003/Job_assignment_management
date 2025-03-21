﻿using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhanDuAnController : ControllerBase
    {
        private readonly IPhanDuAnRepository _phanDuAnRepository;
        private readonly IHubContext<myHub> _hubContext;
        public PhanDuAnController(IPhanDuAnRepository phanDuAnRepository, IHubContext<myHub> hubContext)
        {
            _phanDuAnRepository = phanDuAnRepository;
            _hubContext = hubContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPhanDuAn(string? search, int page = 1)
        {
            var listPhanDuAn = await _phanDuAnRepository.GetAllAsync(search, page);
            return Ok(listPhanDuAn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhanDuAnById(int id)
        {
            var phanDuAn = await _phanDuAnRepository.GetByIdAsync(id);
            return Ok(phanDuAn);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePhanDuAn(PhanDuAnViewModel model)
        {
            var phanDuAn = new PhanDuAn
            {
                MaDuAn = model.MaDuAn,
                TenPhan = model.TenPhan
            };
            var result = await _phanDuAnRepository.CreateAsync(phanDuAn);
            await _hubContext.Clients.All.SendAsync("loadDuAn");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhanDuAn(int id, PhanDuAnViewModel model)
        {
            var phanDuAn = new PhanDuAn
            {
                TenPhan = model.TenPhan
            };
            var result = await _phanDuAnRepository.UpdateAsync(id, phanDuAn);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhanDuAn(int id)
        {
            var result = await _phanDuAnRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
