using Domain;
using Microsoft.EntityFrameworkCore;


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
        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.Include(x => x.userInformation).Include(x => x.userInformation.ProfilePicture).Include(x => x.userInformation.PlaceOfResidenceInfo).
                FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.userInformation).Include(x => x.userInformation.ProfilePicture).Include(x => x.userInformation.PlaceOfResidenceInfo).
                FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task DeleteUserAsync(User user)
        {
            _context.Remove(user);
        }
    }
}
