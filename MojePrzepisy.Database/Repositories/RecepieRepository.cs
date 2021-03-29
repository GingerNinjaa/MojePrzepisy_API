using System.Linq;
using Microsoft.EntityFrameworkCore;
using MojePrzepisy.Database.Entities;
using MojePrzepisy.Database.Repositories.Base;

namespace MojePrzepisy.Database.Repositories
{
    public class RecepieRepository : BaseRepository<Recepie>
    {
        protected override DbSet<Recepie> DbSet => _dbContext.Recepies;

        public RecepieRepository(MojePrzepisyDbContext dbContext) : base(dbContext) {}

        public void UpdateSetting(Recepie setting)
        {
            
            SaveChanges();
            return;

        }
    }
}
