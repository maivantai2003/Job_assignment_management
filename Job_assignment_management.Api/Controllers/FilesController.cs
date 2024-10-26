using Job_assignment_management.Domain.Entities;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Repositories;
using Job_assignment_management.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesRepository _filesRepository;

        public FilesController(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }
        [HttpGet]
        public async  Task<IActionResult> GetAllFiles()
        {
            return Ok(await _filesRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFiles(int id)
        {
            return Ok(await _filesRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFiles(FilesViewModel model)
        {
            var file = new Files()
            {
               TenFile = model.TenFile,
               DuongDan = model.DuongDan,
               LoaiFile = model.LoaiFile,
               KichThuocFile = model.KichThuocFile,
            };
            var res = await _filesRepository.CreateAsync(file);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiles(int id)
        {
            int mafile = await _filesRepository.DeleteAsync(id);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok(mafile);
        }
    }
}
