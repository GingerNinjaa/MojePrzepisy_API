using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MojePrzepisy.Database.Entities;
using MojePrzepisy.Database.Repositories.Base;

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
                    // return BadRequest("User with same email already exists");
                }
                var userObj = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    // Password = SecurePasswordHasherHelper.Hash(user.Password)
                    Password = user.Password,
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
                var userEmail = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
                if (userEmail == null)
                {
                    return false;
                    //return NotFound();
                }

                // var password = SecurePasswordHasherHelper.Verify(user.Password);
                if (userEmail.Password.Equals(user.Password) == false)
                {
                    return false;
                    //return Unauthorized();
                }

                //var token = _authService.GenerateAccessToken(claims);
                //JwtSecurityToken token = GenerateJSONWebToken(user);
                //var token = GenerateJSONWebToken(user);

                //return new ObjectResult(new
                //{
                //    access_token = token,
                //    //creation_Time = token.ValidFrom,
                //    //expiration_Time = token.ValidTo,
                //    user_id = userEmail.Id,
                //    user_Name = userEmail.Name
                //});

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
