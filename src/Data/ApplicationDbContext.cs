using Microsoft.EntityFrameworkCore;
using test_cargo_tracker_api.src.Models;
using test_cargo_tracker_api.src.Models.Container;
using test_cargo_tracker_api.src.Models.Movements;

namespace test_cargo_tracker_api.src.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<ContainerModel> Container { get; set; }
        public DbSet<MovementModel> Movements { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovementModel>()
                .HasOne<ContainerModel>()
                .WithMany(c => c.Movements)
                .HasForeignKey(m => m.ContainerId);
        }
    }
}
