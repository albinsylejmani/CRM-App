using Microsoft.EntityFrameworkCore;
using CrmProject.Models;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace CrmProject.Database
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        // Other DbSet properties for your entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings and relationships
            // ...
        }
    }
}
