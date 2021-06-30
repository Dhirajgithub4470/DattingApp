using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatatingRepository _repos;
        private readonly IMapper _mapper;

        public UsersController(IDatatingRepository repos, IMapper mapper)
        {
            _mapper = mapper;
            _repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repos.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDTO>>(users);
            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repos.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailedDTO>(user);
            return Ok(userToReturn);

        }
    }
}