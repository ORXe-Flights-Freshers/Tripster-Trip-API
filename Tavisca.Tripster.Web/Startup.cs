using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Tavisca.Tripster.Contracts.DatabaseSettings;
using Tavisca.Tripster.Contracts.Repository;
using Tavisca.Tripster.Contracts.Service;
using Tavisca.Tripster.Core.Service;
using Tavisca.Tripster.Data.Models;
using Tavisca.Tripster.MongoDB.Repository;
using Tavisca.Tripster.MongoDB.UnitOfWork;
using Tavisca.Tripster.Web.Middleware;

namespace Tavisca.Tripster.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            Log.Information("Starting up");
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<TripDatabaseSettings>(
        Configuration.GetSection(nameof(TripDatabaseSettings)));
            services.AddSingleton<TripDatabaseSettings>();
            services.AddSingleton<TripDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<TripDatabaseSettings>>().Value);
            services.AddScoped<TripUnitOfWork>();
            services.AddScoped<ITripService, TripService>();
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });
            services.AddMvc()
                            .AddMvcOptions(o => o.OutputFormatters.Add(
                        new XmlDataContractSerializerOutputFormatter()
                        ));
            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddSerilog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseMiddleware<SerilogMiddleware>();
            app.UseCors("AllowAll");
            app.UseMvc();
         
        }
    }
}
