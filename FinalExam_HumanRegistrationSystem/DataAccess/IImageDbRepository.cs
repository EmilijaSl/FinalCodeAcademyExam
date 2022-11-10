using Domain;

namespace DataAccess
{
    public interface IImageDbRepository
    {
        Task<Image> AddImageAsync(Image image);
        Task<Image> GetImageAsync(int id);
        Task SaveChangesAsync();
        Task ChangeProfilePicAsync(int userId, byte[] imageBytes, string contentType);
    }
}
