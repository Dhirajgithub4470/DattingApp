using DatingApp.API.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DatingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Default line below commenting and modifying to call SeedUsers() in Seed class,
            which will populate data into our database if there is no data. This is very useful while developing,
            If we have bad data in database just need to drop database using commads below and recreate. 

            Command to drop database: dotnet ef database drop
            Command to recreate database: dotnet watch run
            */

            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    Seed.SeedUsers(context);

                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occoured during migration");
                }
            }

            host.Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
