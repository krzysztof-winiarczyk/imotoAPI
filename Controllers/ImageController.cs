using imotoAPI.Exceptions;
using imotoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace imotoAPI.Controllers
{
    [Route("api/image")]
    [Controller]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public ActionResult GetFile([FromQuery] string fileName)
        {
            var rootPath = Directory.GetCurrentDirectory();
            var filePath = $"{rootPath}/Images/{fileName}";
            bool fileExists = System.IO.File.Exists(filePath);

            if (!fileExists)
                return NotFound();

            var contentProvider = new FileExtensionContentTypeProvider();
            contentProvider.TryGetContentType(filePath, out string contentType);

            var fileContent = System.IO.File.ReadAllBytes(filePath);
            
            return File(fileContent, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Upload([FromQuery] int annoucementId, [FromForm] IFormFile file)
        {
            //TODO: check if announcement of annoucementId exists
            //TODO: chekc if uploading user is owmer of annoucement
            if (file != null && file.Length > 0  && file.ContentType == "image/jpeg")
            {
                var rootPath = Directory.GetCurrentDirectory();
                var fileName = $"img{DateTime.Now.ToString("yyyyMMddHHmmssff")}.jpg";
                var fullPath = $"{rootPath}/Images/{fileName}";

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                _imageService.AddPhoto(annoucementId, fileName);

                return Ok();
            }
            return BadRequest();
        }
    }
}
