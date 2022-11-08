using DataAccess;
using FinalExam_HumanRegistrationSystem.Dto;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Image = Domain.Image;

namespace BusinessLogic
{
    public class ImagesService : IImagesService
    {
        private readonly IImageDbRepository _dbRepository;

        public ImagesService(IImageDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<Image> AddImageAsync(byte[] imageBytes, string contentType)
        {
            var image = new Image
            {
                ImageBytes = imageBytes,
                ContentType = contentType,

            };
            await _dbRepository.AddImageAsync(image);
            await _dbRepository.SaveChangesAsync();
            return image;
        }

        public async Task<Image> GetImageAsync(int id)
        {
            return await _dbRepository.GetImageAsync(id);
        }
        public async Task<byte[]> ResizeImage(byte[] imageBytes, string contentType)
        {
            using var memoryStream = new MemoryStream(imageBytes);
            using var originalBitmapImage = new Bitmap(memoryStream);
            var resizedImage = new Bitmap(200, 200);

            using var graphics = Graphics.FromImage(resizedImage);

            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphics.DrawImage(originalBitmapImage, 0, 0, 200, 200);

            using var stream = new MemoryStream();
            resizedImage.Save(stream, ImageFormat.Jpeg);
            imageBytes = stream.ToArray();

            return imageBytes;
        }
        public async Task<byte[]> GetImageBytesAsync(SignupDto dto)
        {
            using var memoryStream = new MemoryStream();
            dto.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();
            var resizedImage = await ResizeImage(imageBytes, dto.Image.ContentType);
            return resizedImage;
        }
        public async Task<byte[]> GetImageBytesForProfilePicChangeAsync(ImageUploadRequest imageDto)
        {
            using var memoryStream = new MemoryStream();
            imageDto.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();
            var resizedImage = await ResizeImage(imageBytes, imageDto.Image.ContentType);

            return resizedImage;
        }
        //public async Task ChangeProfilePicAsync(int userId, byte[] imageBytes, string contentType)
        //{
        //    await _dbRepository.ChangeProfilePictureAsync(userId, imageBytes, contentType);
        //    await _dbRepository.SaveChangesAsync();
        //}
    }
}
