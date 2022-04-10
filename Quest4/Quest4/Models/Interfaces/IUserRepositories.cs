using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest4.Models.Interfaces
{
    public interface IUserRepositories
    {
        public IEnumerable<User> GetAllUsers();
    }
}
