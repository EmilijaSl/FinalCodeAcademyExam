using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserInformationDbRepository : IUserInformationDbRepository
    {
        private readonly ApplicationDbContext _context;
        public UserInformationDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task InsertUserInformationAsync(UserInformation user)
        {
            await _context.UsersInformation.AddAsync(user);
        }
        public async Task<UserInformation?> GetUserById(int id)
        {
            return await _context.UsersInformation.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
