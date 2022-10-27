﻿using BusinessLogic;
using FinalExam_HumanRegistrationSystem.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam_HumanRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
    
    public class ImageController : ControllerBase
    {
        private readonly IImagesService _imagesService;

        public ImageController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpPost("Upload")]
        public async Task<ActionResult> UploadImage([FromForm] ImageUploadRequest request)
        {
            using var memoryStream = new MemoryStream();
            request.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var savedImage = await _imagesService.AddImageAsync(imageBytes, request.Image.ContentType);

            return Ok(savedImage.Id);
        }

        [HttpGet("Download")]
        public async Task<ActionResult> DownloadImage([FromQuery] int id)
        {
            var image = await _imagesService.GetImageAsync(id);
            return File(image.ImageBytes, image.ContentType);
        }
    }
}
