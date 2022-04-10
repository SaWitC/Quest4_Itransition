using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quest4.Data;
using Quest4.Models;

namespace Quest4.Components.Statuses
{
    public class CheckStatus
    {
        private readonly Ouest4DBContetx _context;
        private readonly UserManager<User> _userManager;

        public CheckStatus(Ouest4DBContetx context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public bool IsStatus(User user , StatusModel status)
        {
            if (user.StatusId == status.Id) return true;
            else return false;
        }

        public async Task<bool> IsStatusAsync(string UserName, string Status)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(UserName);
                var status = await _context.Statuses.FirstOrDefaultAsync(o => o.Title == Status);

                if (user != null && status != null)
                {
                    if (user.StatusId == status.Id) return true;
                    else return false;
                }
                else return true;
            }
            catch
            {
                throw new Exception("User or Status not found");  
            }
        }
    }
}
