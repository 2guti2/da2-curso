using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ObligatorioDA2.Application.Contracts.Users;
using ObligatorioDA2.Application.Contracts.WeatherForecasts;
using ObligatorioDA2.Application.Users;
using ObligatorioDA2.Application.WeatherForecasts;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore;
using ObligatorioDA2.EntityFrameworkCore.Contracts;
using ObligatorioDA2.EntityFrameworkCore.Repositories;

namespace ObligatorioDA2.HttpApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<Context>(
                o => o.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            // Application Services
            services.AddScoped<IForecastService, ForecastService>();
            services.AddScoped<IUserService, UserService>();

            // Repos
            services.AddScoped<IRepository<WeatherForecast>, WeatherForecastRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();

            // services.AddDbContext<Context>(
            //     o => o.UseInMemoryDatabase("ObligatorioDA2")
            // );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ObligatorioDA2.HttpApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ObligatorioDA2.HttpApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
