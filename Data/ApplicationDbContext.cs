using Microsoft.EntityFrameworkCore;
using PI.BackEnd.API.Models;

namespace PI.BackEnd.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }

        public DbSet<EventParticipation> EventParticipation { get; set; }
    }
}
