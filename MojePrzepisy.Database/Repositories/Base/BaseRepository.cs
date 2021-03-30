using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MojePrzepisy.Database.Repositories.Base
{
    //klasa abstrakcyjna która przyjmuje Entity jako tabele z bazydanych
    public  abstract class BaseRepository<Entity> where Entity : class 
    {
        //zmienna przechowująca bazedanych
        protected MojePrzepisyDbContext _dbContext;
        //referencja do tabelki 
        protected abstract DbSet<Entity> DbSet { get; }
        

        public BaseRepository(MojePrzepisyDbContext dbContext)
        {
            this._dbContext = dbContext;
                
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
            {
                list.Add(entity);
            }

            return list;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
