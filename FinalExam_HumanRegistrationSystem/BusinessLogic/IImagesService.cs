using Domain;

namespace BusinessLogic
{
    public interface IImagesService
    {
        Task<Image> AddImageAsync(byte[] imageBytes, string fileName, string contentType);
        Task<Image> GetImageAsync(int id);
    }
}
