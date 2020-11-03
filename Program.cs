using System;
using System.Net.Http;
using System.Threading.Tasks;
using EmailService.Models;
using EmailService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmailService
{
    class Program
    {

<<<<<<< HEAD
        static async Task Main(string[] args)
        {
            var config = InitConfig();
            var host = InitHost();
=======

        static async Task Main(string[] args)
        {

            
            var host = BuildWebHost();
>>>>>>> c7f0d18... Email service
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    Console.WriteLine("What is your email?");
                    string emailTo = Console.ReadLine();
                    string content = ""; //TODO: get content from API
                    var gridService = services.GetRequiredService<GridEmailService>();
                    EmailTemplate emailMessage = gridService.BuildMessage(emailTo, null, null, content);
                    var response = await gridService.SendEmailAsync(emailMessage);
                    Console.WriteLine(response);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }

        }

<<<<<<< HEAD
        private static IConfigurationRoot InitConfig()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        private static IHost InitHost() { 
=======

        private static IHost BuildWebHost()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{env}.json", true, true)
                    .AddEnvironmentVariables()
                    .Build();

>>>>>>> c7f0d18... Email service
            var builder = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddHttpClient();
                 services.AddTransient<GridEmailService>();
<<<<<<< HEAD
=======
                 services.AddSingleton<IConfigurationRoot>(config);
>>>>>>> c7f0d18... Email service
             }).UseConsoleLifetime();

            return builder.Build();
        }
<<<<<<< HEAD

    }
}




=======
    }
}
>>>>>>> c7f0d18... Email service
