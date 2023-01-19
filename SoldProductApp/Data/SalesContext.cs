using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoldProductApp.Data.Model;

namespace SoldProductApp.Data
{
    public class SalesContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Return> Returns { get; set; }
        public SalesContext(DbContextOptions<SalesContext> options) : base(options) 
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data Seeding
            modelBuilder.Seed();
        }
    }
}
