using EmailService.Models;
using EmailService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EmailService
{
    class Program
    {


        static async Task Main(string[] args)
        {
            IConfigurationRoot configurationRoot = InitConfig();
            var host = InitHost(configurationRoot);
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    Console.WriteLine("What is your email?");
                    string emailTo = Console.ReadLine();
                    string subject = "today's joke";
                    string emailFrom = "test@test.com";
                    string emailFromName = "Joke postman";
                    string defaultJoke = "Sorry, no joke for you today";
                    var jokeService = services.GetRequiredService<JokeService>();

                    JokeTemplate joke = await jokeService.GetJokeAsync();
                    string content = joke!=null ? joke.Joke : defaultJoke;

                    var gridService = services.GetRequiredService<GridEmailService>();
                    SendGridMessage emailMessage = gridService.BuildMessage(emailTo, emailFrom, emailFromName, subject, content);
                    bool response = await gridService.SendEmailAsync(emailMessage);

                    Console.WriteLine(response ? "Email was sent successfully" : "Something went wrong");
                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
            }

        }

        private static IConfigurationRoot InitConfig()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();
            return builder.Build();
        }

        private static IHost InitHost(IConfigurationRoot configurationRoot)
        {
            var builder = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddHttpClient();
                 services.AddScoped<GridEmailService>();
                 services.AddScoped<JokeService>();
                 services.AddSingleton<IConfiguration>(configurationRoot);
                 services.Configure<AppConfig>(configurationRoot.GetSection("AppConfig"));
                 //services.Configure<IcanhazdadjokeConfig>(configurationRoot.GetSection("IcanhazdadjokeConfig"));
             }).UseConsoleLifetime();

            return builder.Build();
        }

    }
}
