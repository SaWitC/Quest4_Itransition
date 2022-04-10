using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quest4.Models;
using Quest4.Models.Interfaces;

namespace Quest4.Data.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly UserManager<User> _userManager;

        public UserRepositories(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userManager.Users;
        }
    }
}
