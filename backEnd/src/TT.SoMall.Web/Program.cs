using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Winton.Extensions.Configuration.Consul;

namespace TT.SoMall.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                .CreateLogger();

            try
            {
                Log.Information("Starting web host.");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    hostingContext.Configuration = config.Build();
                    var consul_url = hostingContext.Configuration["Consul_Url"] ?? "http://127.0.0.1:8500";
                    Console.WriteLine($"Consul Url:{consul_url}");
                    Console.WriteLine($"ApplicationName:{env.ApplicationName}");
                    Console.WriteLine($"EnvironmentName:{env.EnvironmentName}");
                    config.AddConsul(
                            $"demo_somall_top/api_host/appsettings.{env.EnvironmentName}.json", options =>
                            {
                                options.ConsulConfigurationOptions =
                                    cco => { cco.Address = new Uri(consul_url); };
                                options.Optional = true;
                                options.ReloadOnChange = true;
                                options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
                            })
                        .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .UseAutofac()
                .UseSerilog();
    }
}