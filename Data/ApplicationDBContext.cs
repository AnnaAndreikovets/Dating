using DatingSite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.Data
{
    public class ApplicationDBContext : DbContext
    {
        static public User User = null!;
        public DbSet<Chats> Chats { get; set; } = null!;
        public DbSet<Blank> Blanks { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Interaction> Interactions { get; set; } = null!;
        public DbSet<Interested> Interesteds { get; set; } = null!;
        public DbSet<InterestedUser> InterestedUsers { get; set; } = null!;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}