using Domain;

namespace DataAccess
{
    public interface IUserInformationDbRepository
    {
        Task InsertUserInformationAsync(UserInformation user);
        Task<UserInformation?> GetUserById(int id);
        Task SaveChangesAsync();
        Task UpdateInfoName(int id, string name);
        Task UpdateInfoLastName(int id, string lastName);
        Task UpdateInfoPersonalCode(int id, string pk);
        Task UpdateInfoPhoneNumber(int id, string phone);
        Task UpdateInfoEmail(int id, string email);
    }
}
