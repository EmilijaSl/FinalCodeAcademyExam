using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUserInformationDbRepository
    {
        Task InsertUserInformationAsync(UserInformation user);
        Task<UserInformation?> GetUserById(int id);
        Task SaveChangesAsync();
    }
}
