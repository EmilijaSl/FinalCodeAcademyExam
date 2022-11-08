using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ImageDbRepository :IImageDbRepository
    {
        private readonly ApplicationDbContext _context;
        public ImageDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Image> AddImageAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            return image;
        }

        public async Task<Image> GetImageAsync(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task ChangeProfilePictureAsync(int userId, Image profilePicture)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            user.userInformation.ProfilePicture = profilePicture;
            _context.Attach(user);
        }
    }
}
