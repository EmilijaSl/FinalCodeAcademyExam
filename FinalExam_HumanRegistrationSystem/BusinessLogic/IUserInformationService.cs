using Domain;

namespace DataAccess
{
    public interface IUserInformationService
    {
        Task UpdateUserNameAsync(int id, string name);
        Task UpdateUserLastNameAsync(int id, string lastName);
        Task UpdateUserPKAsync(int id, string pk);
        Task UpdateUserPhoneAsync(int id, string phone);
        Task UpdateUserEmailAsync(int id, string email);
        Task<UserInformation> GetUserInformationAsync(int id);
    }
}
