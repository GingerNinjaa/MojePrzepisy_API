using Microsoft.EntityFrameworkCore;
using MojePrzepisy.Database.Entities;

namespace MojePrzepisy.Database
{
    public class MojePrzepisyDbContext : DbContext
    {
        public MojePrzepisyDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recepie> Recepies { get; set; }
        public DbSet<PreparationStep> PreparationSteps { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

    }
}
