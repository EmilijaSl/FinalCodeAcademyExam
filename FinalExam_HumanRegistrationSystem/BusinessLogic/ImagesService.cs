using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
