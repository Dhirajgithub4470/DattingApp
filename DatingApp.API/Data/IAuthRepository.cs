using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string passsword);
        Task<User> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
