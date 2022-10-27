using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUserDbRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task InsertUserAsync(User user);
        Task<User?> GetUserById(int id);
        Task SaveChangesAsync();
        
    }
}
