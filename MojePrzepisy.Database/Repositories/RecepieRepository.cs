using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


        public RecepieRepository(MojePrzepisyDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IQueryable<Recepie>> GetRecepieById(int id)
        {
            try
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
            catch (Exception e)
            {
                return null;
            }
   
        }


        public object GetRecepiePaginated(int? pageNumber, int? pageSize)
        {
            try
            {
                // Pagination
                var currentPageNumber = pageNumber ?? 1;
                var currentPageSize = pageSize ?? 5;

                //var recepies = from recipe in _dbContext.Recepies
                //    select new
                //    {
                //        Id = recipe.Id,
                //        Title = recipe.Title,
                //        ImageUrl = recipe.ImageUrl,
                //        PreparationTime = recipe.PreparationTime,
                //        Category = recipe.Category,
                //        Difficulty = recipe.Difficulty,
                //        People = recipe.People
                //    };

                var recepies = _dbContext.Recepies.Select(recepie => new
                {
                    recepie.Id,
                    recepie.Title,
                    recepie.ImageUrl,
                    recepie.PreparationTime,
                    recepie.Category,
                    recepie.Difficulty,
                    recepie.People
                });

                return recepies.Skip((currentPageNumber -1) * currentPageSize).Take(currentPageSize);
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public object FindRecepie(string recipeTitle)
        {
            try
            {
                var recepies = _dbContext.Recepies.Where(recepie => recepie.Title.Contains(recipeTitle))
                    .Select(recepie => new
                    {
                        recepie.Id,
                        recepie.Title,
                        recepie.ImageUrl,
                    }).Take(20).ToList();

                return recepies;
            }
            catch (Exception e)
            {
                return false;
            }
            //var recepies = from recipe in _dbContext.Recepies
            //    where recipe.Title.Contains(recipeTitle)
            //    select new
            //    {
            //        Id = recipe.Id,
            //        Title = recipe.Title,
            //        ImageUrl = recipe.ImageUrl
            //    };
        }

        public bool AddRecepie(Recepie recepie)
        {
            try
            {
                if (recepie== null)
                {
                    return false;
                }

                _dbContext.Recepies.Add(recepie);
                SaveChanges();

                //return StatusCode(StatusCodes.Status201Created);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool AddRecepieImg(Recepie recepie)
        {

            try
            {
                var recepieInDatabase = _dbContext.Recepies.Where(x => x.Title == recepie.Title).FirstOrDefault();

                if (recepieInDatabase != null)
                {
                    var guid = Guid.NewGuid();
                    var filePath = Path.Combine("wwwroot", guid + ".jpg");
                    //var filePath = Path.Combine("wwwroot", guid + ".jpg");
                    if (recepie.Image != null)
                    {
                        var fileStream = new FileStream(filePath, FileMode.Create);
                        recepie.Image.CopyTo(fileStream);
                    }

                    recepieInDatabase.ImageUrl = filePath.Remove(0, 7);

                    _dbContext.SaveChanges();

                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool EditRecepieIMG(int id, Recepie recepie)
        {
            try
            {
                var recepieInDatabase = _dbContext.Recepies.Where(x => x.Id == id).FirstOrDefault();
                if (recepieInDatabase == null)
                {
                    return false;
                    //return NotFound("No record found against this Id");
                }
                else
                {
                    var guid = Guid.NewGuid();
                    var filePath = Path.Combine("wwwroot", guid + ".jpg");
                    if (recepie.Image != null)
                    {
                        var fileStream = new FileStream(filePath, FileMode.Create);
                        recepie.Image.CopyTo(fileStream);
                        recepieInDatabase.ImageUrl = filePath.Remove(0, 7);
                    }

                    _dbContext.SaveChanges();
                    return true;
                    //return Ok("Record updated successfully");
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool EditRecepie(int id, Recepie recepie)
        {
            try
            {
                var recepieInDatabase = this._dbContext.Recepies.Where(y => y.Id == id)
                    .Include(x => x.Ingredients)
                    .Include(c => c.PreparationSteps).FirstOrDefault();
                if (recepieInDatabase == null)
                {
                    return false;
                    //return NotFound("No record found against this Id");
                }
                else
                {

                    recepieInDatabase.Title = recepie.Title;
                    recepieInDatabase.Description = recepie.Description;
                    recepieInDatabase.PreparationTime = recepie.PreparationTime;
                    recepieInDatabase.CookingTime = recepie.CookingTime;
                    recepieInDatabase.People = recepie.People;
                    recepieInDatabase.Difficulty = recepie.Difficulty;
                    recepieInDatabase.Category = recepie.Category;
                    recepieInDatabase.Ingredients = recepie.Ingredients;
                    recepieInDatabase.PreparationSteps = recepie.PreparationSteps;

                    SaveChanges();
                    return true;
                    //return Ok("Record updated successfully");
                }
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public bool DeleteById(int id)
        {
            try
            {
                var recepieId = _dbContext.Recepies.Find(id);
                var ingredientsesList = _dbContext.Ingredients.Where(x => x.RecepieId.Equals(id)).ToList();
                var preparationStepsList = _dbContext.PreparationSteps.Where(x => x.RecepieId.Equals(id)).ToList();

                if (recepieId == null)
                {
                    return false;
                    // return NotFound("No record found against this Id");
                }
                else
                {
                    _dbContext.Recepies.Remove(recepieId);
                    _dbContext.Ingredients.RemoveRange(ingredientsesList);
                    _dbContext.PreparationSteps.RemoveRange(preparationStepsList);
                    _dbContext.SaveChanges();
                    return true;
                    //return Ok("Record deleted");
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
