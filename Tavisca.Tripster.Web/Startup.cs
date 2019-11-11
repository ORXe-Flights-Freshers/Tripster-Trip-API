using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Tavisca.Tripster.Contracts.DatabaseSettings;
using Tavisca.Tripster.Contracts.Service;
using Tavisca.Tripster.Core.Service;
using Tavisca.Tripster.MongoDB.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Tavisca.Tripster.Web.Models;

namespace Tavisca.Tripster.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
            services.AddSingleton<TripUnitOfWork>();
            services.AddSingleton<UserUnitOfWork>();
            services.AddSingleton<ITripService, TripService>();
            services.AddSingleton<IUserService, UserService>();
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

            services.AddDbContext<TaviscaTripsterWebContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TaviscaTripsterWebContext")));
            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowAll");
            app.UseMvc();
         
        }
    }
}
