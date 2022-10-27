using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDbRepository : IUserDbRepository
    {
        private readonly ApplicationDbContext _context;

        public UserDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task InsertUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public async Task InsertUserFullInfoAsync(User user, UserInformation info, PlaceOfResidence place, Image image)
        {
            await _context.Users.AddAsync(user);
            await _context.UsersInformation.AddAsync(info);
            await _context.Places.AddAsync(place);
            await _context.Images.AddAsync(image);
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
