using Microsoft.EntityFrameworkCore;

namespace PebCareHub.Entities
{
    public class PetHubDbContext :DbContext
    {
        public PetHubDbContext(DbContextOptions<PetHubDbContext> options):base(options) { 

        }
        public DbSet<Custormer> Custormers { get; set;}

    }
}
