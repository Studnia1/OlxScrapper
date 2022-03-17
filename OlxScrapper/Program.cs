using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using Coravel;
using Microsoft.Extensions.Hosting;
using OlxScrapper.Services;
using Microsoft.Extensions.DependencyInjection;

namespace OlxScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()               
                .ConfigureServices((context, services) =>
                {
                    services.AddScheduler();
                    services.AddTransient<IScrapperServiceFactory, ScrapperServiceFactory>();
                })
                .UseSerilog()
                .Build();

            host.Services.UseScheduler(scheduler =>
            {
                var jobSchedule = scheduler.Schedule<IScrapperServiceFactory>();
                jobSchedule
                    .EverySecond();
            });


            host.Run();

            var svc = ActivatorUtilities.CreateInstance<IScrapperServiceFactory>(host.Services);
            svc.AddNewService("test", 1);
 
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
