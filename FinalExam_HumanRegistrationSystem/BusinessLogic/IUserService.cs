using Domain;

namespace BusinessLogic
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(string username, string password, string name, string lastName, string personalCode, string phoneNumber, string email, string city, string street, string houseNumber, string apartmentNumber, Image image);
        Task<(bool authenticationSuccessful, User? user)> LoginAsync(string username, string password);
        Task<User> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id);
    }
}
