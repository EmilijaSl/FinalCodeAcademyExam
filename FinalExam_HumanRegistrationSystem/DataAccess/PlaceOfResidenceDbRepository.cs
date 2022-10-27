using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
