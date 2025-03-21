﻿using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Api.Quarts;
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Job_assignment_management.Shared.Common.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Quartz;
using Quartz.Core;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CongViecController : ControllerBase
    {
        private readonly ICongViecRepository _congViecRepository;
        private readonly IHubContext<myHub> _hubContext;

        public CongViecController(ICongViecRepository congViecRepository, IHubContext<myHub> hubContext)
        {
            _congViecRepository = congViecRepository;
            _hubContext = hubContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCongViec(string? search, int page = 1)
        {
            var listCongViec = await _congViecRepository.GetAllAsync(search, page);
            return Ok(listCongViec);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCongViecById(int id)
        {
            try
            {
                var congViec = await _congViecRepository.GetByIdAsync(id);
                return Ok(congViec);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error = ErrorMessages.FindFailed
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCongViec(CongViecViewModel model)
        {
            try
            {
                var congViec = new CongViec
                {
                    MaPhanDuAn = model.MaPhanDuAn,
                    MaCongViecCha = model.MaCongViecCha,
                    TenCongViec = model.TenCongViec,
                    MoTa = model.MoTa,
                    MucDoUuTien = model.MucDoUuTien,
                    ThoiGianBatDau = model.ThoiGianBatDau,
                    ThoiGianKetThuc = model.ThoiGianKetThuc,
                    TrangThaiCongViec = model.TrangThaiCongViec,
                    MucDoHoanThanh = model.MucDoHoanThanh
                };
                var result = await _congViecRepository.CreateAsync(congViec);
                await _hubContext.Clients.All.SendAsync("loadCongViec");
                return Ok(result);
            }
            catch (Exception ex) { 
                return Ok(new
                {
                    error = ErrorMessages.CreateFailed
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCongViec(int id, UpdateCongViecViewModel model)
        {
            try
            {
                var congViec = new CongViec
                {
                    MaCongViec=model.MaCongViec,
                    TenCongViec = model.TenCongViec,
                    MoTa = model.MoTa,
                    MucDoUuTien = model.MucDoUuTien,
                    ThoiGianBatDau = model.ThoiGianBatDau,
                    ThoiGianKetThuc = model.ThoiGianKetThuc,
                };
                var result = await _congViecRepository.UpdateAsync(id, congViec);
                await _hubContext.Clients.All.SendAsync("loadCongViec");
                return Ok(true);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error = ErrorMessages.UpdateDateFailed
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongViec(int id)
        {
            try
            {
                var result = await _congViecRepository.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error =ErrorMessages.DeleteFailed
                });
            }
        }
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateCompleteTask(int id,bool trangThai,double mucDo)
        {
            try
            {
                var result = await _congViecRepository.UpdateComplete(id, trangThai, mucDo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    error = ErrorMessages.UpdateDateFailedMessage("Công Việc")
                });
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTaskDay(int id,DateTime thoiGianKetThuc)
        {
            try
            {
                var result = await _congViecRepository.UpdateTaskDay(id, thoiGianKetThuc);
                return Ok(result);
            }
            catch (Exception ex) {
                return Ok(new
                {
                    error=ErrorMessages.UpdateDateFailed
                });
            }
        }
    }
}
