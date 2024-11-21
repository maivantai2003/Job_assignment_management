
using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Shared.Common;
using Job_assignment_management.Shared.Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietTraoDoiThongTinController : ControllerBase
    {
        private readonly IChiTietTraoDoiThongTinRepository _chiTietTraoDoiThongTin;
        public ChiTietTraoDoiThongTinController(IChiTietTraoDoiThongTinRepository chiTietTraoDoiThongTin)
        {
            _chiTietTraoDoiThongTin = chiTietTraoDoiThongTin;
        }
        [HttpPost]   
        
        public async Task<IActionResult> AddChiTietTraoDoi(ChiTietTraoDoiThongTinViewModel chiTietTraoDoi)
        {
            try
            {
                var chiTiet = new ChiTietTraoDoiThongTin()
                {
                    MaFile = chiTietTraoDoi.MaFile,
                    MaTraoDoi = chiTietTraoDoi.MaTraoDoi
                };
                var result = await _chiTietTraoDoiThongTin.AddAsync(chiTiet);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    error = ErrorMessages.CreateFailed
                });
            }
        }
    }
}
