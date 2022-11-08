using Domain;

namespace DataAccess
{
    public interface IUserDbRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task InsertUserAsync(User user);
        Task<User?> GetUserById(int id);
        Task SaveChangesAsync();
        Task<User> GetUserByIdAsync(int id);
        Task DeleteUserAsync(User user);
    }
}
