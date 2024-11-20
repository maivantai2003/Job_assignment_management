using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_assignment_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public FileUploadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var cloudinary = new Cloudinary(new Account(
                _configuration.GetSection("CloudinarySettings:CloudName").Value,
                _configuration.GetSection("CloudinarySettings:ApiKey").Value,
                _configuration.GetSection("CloudinarySettings:ApiSecret").Value
            ));

            var uploadResult = new RawUploadResult();

            // Kiểm tra xem file có phải là ảnh không
            var allowedImageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (allowedImageExtensions.Contains(extension))
            {
                // Upload ảnh
                var imageUploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream())
                };
                uploadResult = await cloudinary.UploadAsync(imageUploadParams);
            }
            else
            {
                // Upload tệp không phải ảnh
                var rawUploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream())
                };
                uploadResult = await cloudinary.UploadAsync(rawUploadParams);
            }

            // Kiểm tra lỗi từ Cloudinary
            if (uploadResult.Error != null)
            {
                return BadRequest(uploadResult.Error.Message);
            }

            return Ok(new { url = uploadResult.Url.ToString(), publicId = uploadResult.PublicId });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFile(string publicId, IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("No file uploaded.");
            }

            if (string.IsNullOrEmpty(publicId))
            {
                return BadRequest("Public ID is missing.");
            }

            var cloudinary = new Cloudinary(new Account(
                _configuration.GetSection("CloudinarySettings:CloudName").Value,
                _configuration.GetSection("CloudinarySettings:ApiKey").Value,
                _configuration.GetSection("CloudinarySettings:ApiSecret").Value
            ));
            // Xóa file cũ
            var deletionParams = new DeletionParams(publicId);
            var deletionResult = await cloudinary.DestroyAsync(deletionParams);

            if (deletionResult.Result != "ok")
            {
                return BadRequest("Failed to delete old file.");
            }

            // Upload file mới
            var uploadResult = new RawUploadResult();
            var allowedImageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (allowedImageExtensions.Contains(extension))
            {
                var imageUploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream())
                };
                uploadResult = await cloudinary.UploadAsync(imageUploadParams);
            }
            else
            {
                var rawUploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream())
                };
                uploadResult = await cloudinary.UploadAsync(rawUploadParams);
            }

            if (uploadResult.Error != null)
            {
                return BadRequest(uploadResult.Error.Message);
            }

            return Ok(new { url = uploadResult.Url.ToString(), publicId = uploadResult.PublicId });
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteFile(string publicId)
        {
            if (string.IsNullOrEmpty(publicId))
            {
                return BadRequest("Public ID is missing.");
            }

            var cloudinary = new Cloudinary(new Account(
                _configuration.GetSection("CloudinarySettings:CloudName").Value,
                _configuration.GetSection("CloudinarySettings:ApiKey").Value,
                _configuration.GetSection("CloudinarySettings:ApiSecret").Value
            ));

            // Kiểm tra xem publicId có dấu chấm không
            ResourceType resourceType = publicId.Contains(".") ? ResourceType.Raw : ResourceType.Image;

            // Tạo đối tượng GetResourceParams
            var resourceParams = new GetResourceParams(publicId)
            {
                ResourceType = resourceType // Gán loại tài nguyên
            };

            // Lấy thông tin chi tiết về file
            var resourceResult = await cloudinary.GetResourceAsync(resourceParams);
            if (resourceResult.Error != null)
            {
                return BadRequest($"File not found: {resourceResult.Error.Message}");
            }

            // Xóa file
            var deletionParams = new DeletionParams(publicId)
            {
                ResourceType = resourceType // Gán loại tài nguyên
            };

            var deletionResult = await cloudinary.DestroyAsync(deletionParams);
            if (deletionResult.Result == "ok" || deletionResult.Result == "not found")
            {
                return Ok($"File deleted successfully or not found. {deletionResult.Error}");
            }

            return BadRequest($"Failed to delete file: {deletionResult.Error?.Message ?? "Unknown error"}");
        }

    }
}
