using Microsoft.EntityFrameworkCore;
using TestUser.Models;

namespace TestUser.Context
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
    
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        
        }
    }
}