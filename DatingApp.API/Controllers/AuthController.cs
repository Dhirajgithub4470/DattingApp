using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthRepository _authrepo;
        public readonly IConfiguration _config;

        public AuthController(IAuthRepository authrepo, IConfiguration config)
        {
            _authrepo = authrepo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();

            if (await _authrepo.UserExist(userForRegister.Username))
                return BadRequest("UserName Already Exist");

            var userToCreate = new User
            {
                UserName = userForRegister.Username
            };

            var createdUser = await _authrepo.Register(userToCreate, userForRegister.Password);

            return StatusCode(201);

        }

        //[AllowAnonymous]
        [HttpPost("login")]
        //[Route("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLogin)
        {
            var userFromRepo = await _authrepo.Login(userForLogin.Username.ToLower(), userForLogin.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }

    }
}