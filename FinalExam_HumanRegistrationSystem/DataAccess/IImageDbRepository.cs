using Domain;

namespace DataAccess
{
    public interface IImageDbRepository
    {
        Task<Image> AddImageAsync(Image image);
        Task<Image> GetImageAsync(int id);
        Task SaveChangesAsync();
    }
}
