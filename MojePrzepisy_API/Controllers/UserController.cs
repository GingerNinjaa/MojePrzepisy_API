using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MojePrzepisy.Database.Entities;
using MojePrzepisy.Database.Repositories;

namespace MojePrzepisy_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //połączenie do startup
        private UserRepository _settingsRepository;

        private IConfiguration _configuration;

        public UserController(UserRepository settingsRepository, IConfiguration configuration)
        {
            this._settingsRepository = settingsRepository;
            this._configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPut("[action]")]
        public IActionResult Register([FromBody] User user)
        {
            bool resoult = _settingsRepository.Register(user);

            if (resoult == true)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }



        //private object GenerateJSONWebToken(User userInfo)
        //{
        //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
        //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


        //var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
        //    _configuration["Tokens:Issuer"],
        //    //claims,
        //    expires: DateTime.Now.AddMinutes(120),
        //    signingCredentials: credentials);


        ////int? nbf2 = jwtSecurityToken.Payload.Nbf;
        ////int? test = token.Payload.Exp; to dodać 
        //int? exp2 = token.Payload.Exp;
        //int? nbf2 = token.Payload.Nbf;
        //return this.CreateTokenResource(new JwtSecurityTokenHandler().WriteToken((SecurityToken)token), nbf2, exp2);

        //return new JwtSecurityTokenHandler().WriteToken(token);
        // return token;
        //  }

        //private TokenResponse CreateTokenResource(string token, int? validFrom, int? validTo)
        //{
        //    return new TokenResponse()
        //    {
        //        TokenType = "bearer",
        //        AccessToken = token,
        //        ValidFrom = validFrom,
        //        ValidTo = validTo
        //    };
        //}



        //    [AllowAnonymous]
        //    [HttpPost]
        //    public IActionResult Login([FromBody] User user)
        //    {
        //        if (user == null)
        //        {
        //            return StatusCode(StatusCodes.Status401Unauthorized);
        //        }

        //        var result = _settingsRepository.Login(user);

        //        if (result == true)
        //        {

        //            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
        //            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


        //            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
        //                _configuration["Tokens:Issuer"],
        //                //claims,
        //                expires: DateTime.Now.AddMinutes(120),
        //                signingCredentials: credentials);


        //            //int? nbf2 = jwtSecurityToken.Payload.Nbf;
        //            //int? test = token.Payload.Exp; to dodać 
        //            int? exp2 = token.Payload.Exp;
        //            int? nbf2 = token.Payload.Nbf;
        //            //var token = GenerateJSONWebToken(user);
        //            return new ObjectResult(token);

        //            //return Ok(token);
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //}
    }
}

    //public class TokenResponse
    //{
    //    public string TokenType { get; set; }
    //    public string AccessToken { get; set; }
    //    public int? ValidFrom { get; set; }
    //    public int? ValidTo { get; set; }
    //}

