using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PlaceOfResidenceDbRepository : IPlaceOfResidenceDbRepository
    {
        private readonly ApplicationDbContext _context;

        public PlaceOfResidenceDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task InsertUserAsync(PlaceOfResidence user)
        {
            await _context.Places.AddAsync(user);
        }
        public async Task<PlaceOfResidence?> GetUserById(int id)
        {
            return await _context.Places.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task ChangeCityAsync(int userId, string city)
        {
            var existingUser = await _context.Users.Include(u => u.userInformation).Include(u => u.userInformation.PlaceOfResidenceInfo)
            .FirstOrDefaultAsync(u => u.Id == userId);
            existingUser.userInformation.PlaceOfResidenceInfo.City = city;
        }

        public async Task ChangeStreetAsync(int userId, string street)
        {
            var existingUser = await _context.Users.Include(u => u.userInformation).Include(u => u.userInformation.PlaceOfResidenceInfo)
            .FirstOrDefaultAsync(u => u.Id == userId);
            existingUser.userInformation.PlaceOfResidenceInfo.Street = street;
        }

        public async Task ChangeHouseNumberAsync(int userId, string houseNumber)
        {
            var existingUser = await _context.Users.Include(u => u.userInformation).Include(u => u.userInformation.PlaceOfResidenceInfo)
             .FirstOrDefaultAsync(u => u.Id == userId);
            existingUser.userInformation.PlaceOfResidenceInfo.HouseNumber = houseNumber;
        }

        public async Task ChangeApartmentNumber(int userId, string apartmentNumber)
        {
            var existingUser = await _context.Users.Include(u => u.userInformation).Include(u => u.userInformation.PlaceOfResidenceInfo)
        .FirstOrDefaultAsync(u => u.Id == userId);
            existingUser.userInformation.PlaceOfResidenceInfo.ApartmentNumber = apartmentNumber;
        }
    }
}
