using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public async Task UpdateInfoName(int id, string name)
        {
            var existingUser = await _context.Users.Include(x => x.userInformation).FirstOrDefaultAsync(u => u.Id == id);
            existingUser.userInformation.Name = name;
        }
        public async Task UpdateInfoLastName(int id, string lastName)
        {
            var existingUser = await _context.Users.Include(x => x.userInformation).FirstOrDefaultAsync(u => u.Id == id);
            existingUser.userInformation.LastName = lastName;
        }
        public async Task UpdateInfoPersonalCode(int id, string pk)
        {
            var existingUser = await _context.Users.Include(x => x.userInformation).FirstOrDefaultAsync(u => u.Id == id);
            existingUser.userInformation.PersonalCode = pk;
        }
        public async Task UpdateInfoPhoneNumber(int id, string phone)
        {
            var existingUser = await _context.Users.Include(x => x.userInformation).FirstOrDefaultAsync(u => u.Id == id);
            existingUser.userInformation.PhoneNumber = phone;
        }
        public async Task UpdateInfoEmail(int id, string email)
        {
            var existingUser = await _context.Users.Include(x => x.userInformation).FirstOrDefaultAsync(u => u.Id == id);
            existingUser.userInformation.Email = email;
        }

    }
}
