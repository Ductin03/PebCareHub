using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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


            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(c => c.Product)
                .HasForeignKey(p => p.CategoryId )
                .OnDelete(DeleteBehavior.Restrict);
  

            modelBuilder.Entity<Pet>()
                .HasOne(p=>p.PetCategory)
                .WithMany(c=>c.Pets)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pet>()
               .HasOne(p => p.Seller)
               .WithMany(u => u.Pet)  
               .HasForeignKey(p => p.CreatedBy)  
               .OnDelete(DeleteBehavior.Restrict);

                  
            modelBuilder.Entity<Product>()
               .HasOne(p => p.Seller) 
               .WithMany(u => u.Products) 
               .HasForeignKey(p => p.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);


        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetCategory> Petcategory { get; set; }

        public DbSet<ProductCategory> ProductsCategory { get; set; }


    }
}
