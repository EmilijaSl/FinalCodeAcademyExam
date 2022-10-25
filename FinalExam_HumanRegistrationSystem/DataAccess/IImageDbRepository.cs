using Domain;

namespace DataAccess
{
    public interface IImageDbRepository
    {
        Task AddImageAsync(Image image);
        Task<Image> GetImageAsync(int id);
        Task SaveChangesAsync();
    }
}
