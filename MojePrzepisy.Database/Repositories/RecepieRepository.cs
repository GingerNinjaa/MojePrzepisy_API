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
        //private IRecepieRepository _recepieRepository;

        public RecepieRepository( MojePrzepisyDbContext dbContext) : base(dbContext)
        {
         
        }

        public object GetRecepieById(int id)
        {
            //var recipe = this._dbContext.Recepies
            //    .Include(x => x.Ingredients)
            //    .Include(c => c.PreparationSteps).Where(v => v.Id.Equals(id));

            var test = this._dbContext.Recepies.Where(i => i.Id.Equals(id));


            return test;
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
