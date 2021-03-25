using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace TT.SoMall
{
    public class Program
    {
        public static int Main(string[] args)
        {
#if DEBUG
            var elasticsearch = "http://127.0.0.1:9200";
#else
             var elasticsearch = "http://elasticsearch:9200";
#endif

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearch))
                {
                    // AutoRegisterTemplate = true,
                    // AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
                    // CustomFormatter = new EcsTextFormatter()
                })
                .CreateLogger();

            try
            {
                Log.Warning("Starting TT.SoMall.IdentityServer.");
                Log.Warning($"Elastics Url {elasticsearch}");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TT.SoMall.IdentityServer terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                // .ConfigureAppConfiguration((hostingContext, config) =>
                // {
                //     var env = hostingContext.HostingEnvironment;
                //     hostingContext.Configuration = config.Build();
                //     string consul_url = hostingContext.Configuration["Consul_Url"] ?? "http://127.0.0.1:8500";
                //     Console.WriteLine($"Consul Url:{consul_url}");
                //     Console.WriteLine($"ApplicationName:{env.ApplicationName}");
                //     Console.WriteLine($"EnvironmentName:{env.EnvironmentName}");
                //     config.AddConsul(
                //             $"demo_somall_top/api_host/appsettings.{env.EnvironmentName}.json", options =>
                //             {
                //                 options.ConsulConfigurationOptions =
                //                     cco => { cco.Address = new Uri(consul_url); };
                //                 options.Optional = true;
                //                 options.ReloadOnChange = true;
                //                 options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
                //             })
                //         .AddEnvironmentVariables();
                // })
                .UseAutofac()
                .UseSerilog();
    }
}