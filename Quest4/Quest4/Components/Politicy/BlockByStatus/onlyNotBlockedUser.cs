using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest4.Components.Politicy.BlockByStatus
{
    public class onlyNotBlockedUser : IAuthorizationRequirement
    {
        public int status { get; set; }
        public onlyNotBlockedUser(int status)
        {
        }
    }
}
