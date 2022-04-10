using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quest4.Data;
using Quest4;
using Quest4.Data.Repositories;

namespace Quest4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host= CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<Ouest4DBContetx>();
                    SampleData.Initialise(context);
                }
                catch (Exception ex)
                {
                    var loger = service .GetRequiredService<ILogger<Program>>();
                    loger.LogError(ex, "Error in system");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
