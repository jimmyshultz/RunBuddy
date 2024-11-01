using Microsoft.EntityFrameworkCore;
using RunBuddyBackend.Models;

namespace RunBuddyBackend.Data
{
    public class RunBuddyContext : DbContext
    {
        public RunBuddyContext(DbContextOptions<RunBuddyContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships or other constraints here
        }
    }
}
