using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Quest4.Models;

namespace Quest4.Data
{
    public class Ouest4DBContetx: IdentityDbContext<User>
    {
        public Ouest4DBContetx(DbContextOptions<Ouest4DBContetx> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //public DbSet<User> Users { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }
    }
}
