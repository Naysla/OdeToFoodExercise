using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFoodExercise.Data;

namespace OdeToFoodExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateWebHostBuilder(args).Build();
            MigrateDatabase(host);
            host.Run();
        }
        private static void MigrateDatabase(IwebHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<OdeToFoodExerciseDBContext>();
                db.Database.Migrate();
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
