using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MojePrzepisy.Database.Entities;
using MojePrzepisy.Database.Repositories.Base;
using System.Web.Helpers;

namespace MojePrzepisy.Database.Repositories
{
    public class UserRepository : BaseRepository<User>
    {

        protected override DbSet<User> DbSet => _dbContext.Users;
        //private IRecepieRepository ;


        public UserRepository(MojePrzepisyDbContext dbContext) : base(dbContext)
        {

        }

        public bool Register(User user)
        {
            try
            {
                var userWithSameEmail = _dbContext.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                if (userWithSameEmail != null)
                {
                    return false;
                }
                var userObj = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = SavePassword(user.Password),
                    //Password = user.Password, oryginal
                    Role = "User"
                };
                _dbContext.Users.Add(userObj);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Login(User user)
        {
            try
            {
                //Email checking
                var userEmail = _dbContext.Users.Where(x => x.Email.Equals(user.Email)).Select(user1 => user1.Email).FirstOrDefault();
                if (userEmail == null)
                {
                    return false;
                    //return NotFound();
                }

                //Password checking
                if (CheckPassword(user.Password, userEmail) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string SavePassword(string unhashedPassword)
        {
            string hashedPassword = Crypto.HashPassword(unhashedPassword);
            return hashedPassword;
        }

        public bool CheckPassword(string unhashedPassword, string email)
        {
            string savedHashedPassword = _dbContext.Users.Where(user => user.Email.Equals(email)).Select(user => user.Password).FirstOrDefault();//get hashedPassword from where you saved it
            return Crypto.VerifyHashedPassword(savedHashedPassword, unhashedPassword);
        }
    }
}
