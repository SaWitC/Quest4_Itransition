using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quest4.Models;

namespace Quest4.Data.Repositories
{
    public class SampleData
    {
        public static void Initialise(Ouest4DBContetx context)
        {
            if (!context.Statuses.Any())
            {
                context.Statuses.AddRange(
                   new StatusModel {  Title = "Baned" },
                   new StatusModel {  Title = "Online" },
                   new StatusModel {  Title = "Ofline" });
                   
                context.SaveChanges();
            }
        }
    }
}
