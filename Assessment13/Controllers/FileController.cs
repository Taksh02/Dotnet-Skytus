using Microsoft.AspNetCore.Mvc;

namespace Assessment13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FileController> _logger;

        public FileController(IWebHostEnvironment env, ILogger<FileController> logger)
        {
            _env = env;
            _logger = logger;
        }

        // =========================
        // FILE UPLOAD
        // =========================
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected.");

            // Path: ProjectRoot/wwwroot/uploads
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _logger.LogInformation("File uploaded: {FileName}", uniqueFileName);

            return Ok(new
            {
                message = "File uploaded successfully",
                fileName = uniqueFileName
            });
        }

        // =========================
        // FILE DOWNLOAD
        // =========================
        [HttpGet("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                _logger.LogWarning("File {FileName} not found", fileName);
                return NotFound("File not found");
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);

            _logger.LogInformation("File downloaded: {FileName}", fileName);

            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
