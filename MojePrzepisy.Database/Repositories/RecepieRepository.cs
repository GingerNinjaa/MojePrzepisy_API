using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MojePrzepisy.Database.Entities;
using MojePrzepisy.Database.Repositories.Base;
using MojePrzepisy.Database.Repositories.Interfaces;

namespace MojePrzepisy.Database.Repositories
{
    public class RecepieRepository : BaseRepository<Recepie>, IRecepieRepository
    {
        protected override DbSet<Recepie> DbSet => _dbContext.Recepies;
        //private IRecepieRepository ;


        public RecepieRepository( MojePrzepisyDbContext dbContext) : base(dbContext)
        {
         
        }

        public IQueryable<Recepie> GetRecepieById(int id)
        {
            var recipe = this._dbContext.Recepies
                .Include(x => x.Ingredients)
                .Include(c => c.PreparationSteps)
                    .Where(v => v.Id.Equals(id));

            //var recipe = this._dbContext.Recepies
            //    .Include(x => x.Ingredients.Where(c => c.RecepieId.Equals(id)))
            //    .Include(c => c.PreparationSteps.Where(a => a.RecepieId.Equals(id))
            //        .Where(v => v.Id.Equals(id)));


            return recipe;
        }

        public void UpdateSetting(Recepie setting)
        {
            SaveChanges();
            return;
        }

        public void UpdateRecepie(Recepie recepie)
        {
            throw new System.NotImplementedException();
        }
    }
}
