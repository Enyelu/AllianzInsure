using AllianzeInsure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AllianzInsure.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
        }
    }
}