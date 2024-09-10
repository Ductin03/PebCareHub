using Microsoft.EntityFrameworkCore;

namespace PebCareHub.Entities
{
    public class PetHubDbContext :DbContext
    {
        public PetHubDbContext(DbContextOptions<PetHubDbContext> options):base(options) { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
   


    }
}
