using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Tavisca.Tripster.Contracts.Entity;
using Tavisca.Tripster.Contracts.Interface;
using Tavisca.Tripster.Contracts.Response;
using Tavisca.Tripster.Core.Provider;
using Tavisca.Tripster.Core.Service;
using Tavisca.Tripster.MongoDB.Repository;
using Tavisca.Tripster.Web.Middleware;

namespace Tavisca.Tripster.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            StaticConfiguration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
            DatabaseSettings.ConnectionString = Configuration["ConnectionString"];
            DatabaseSettings.DatabaseName = Configuration["DatabaseName"];
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfiguration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<ISmtpClientBuilder, SmtpClientBuilder>();

            services.AddSingleton<EmailResponse>();

            services.Configure<SendCredentials>(
                       Configuration.GetSection(nameof(SendCredentials)));

            services.AddSingleton<SendCredentials>(sp =>
                     sp.GetRequiredService<IOptions<SendCredentials>>().Value);
            services.AddTransient<IMailBuilder, MailBuilder>();

            services.AddScoped<SendEmailService>();


            services.AddScoped<TripRepository>();
            services.AddScoped<UserRepository>();

            services.AddScoped<IUserService, UserService>();


            services.AddScoped<ITripService, TripService>();

            services.AddScoped<TripResponse>();
            services.AddScoped<UserResponse>();


            services.AddSingleton<FuelPriceService>();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .WithMethods("GET", "OPTIONS")  
                        .WithMethods("POST", "OPTIONS")
                        .WithMethods("PUT", "OPTIONS")
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
            app.UseHsts();
            app.UseMiddleware<SerilogMiddleware>();
            app.UseCors("AllowAll");
            app.UseMvc();
         
        }
    }
}
