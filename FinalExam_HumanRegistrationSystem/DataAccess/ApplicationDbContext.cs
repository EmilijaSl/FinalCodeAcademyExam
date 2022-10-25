using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PlaceOfResidence> Places { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UsersInformation { get; set; }
        public DbSet<Image> Images { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
