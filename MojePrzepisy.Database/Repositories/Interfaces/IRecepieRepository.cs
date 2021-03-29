using MojePrzepisy.Database.Entities;
using System.Collections.Generic;

namespace MojePrzepisy.Database.Repositories.Interfaces
{
    public interface IRecepieRepository
    {
        List<Recepie> GetAll();
        void UpdateRecepie(Recepie recepie);
        void SaveChanges();
    }
}
