using Microsoft.AspNetCore.Http;
using Validation;

namespace FinalExam_HumanRegistrationSystem.Dto
{
    public class ImageUploadRequest
    {
        [MaxFileSize(5 * 200 * 200)]
        [AllowedExtensions(new[] { ".png", ".jpg" })]
        public IFormFile Image { get; set; }
    }
}
