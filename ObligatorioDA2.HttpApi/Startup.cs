using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ObligatorioDA2.Domain;
using ObligatorioDA2.Domain.Roles;
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
            // services.AddScoped<IForecastService, ForecastService>();
            // services.AddScoped<IUserService, UserService>();

            LoadApplicationServices(services);

            // Repos
            services.AddScoped<IRepository<WeatherForecast>, WeatherForecastRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Role>, RoleRepository>();

            // services.AddDbContext<Context>(
            //     o => o.UseInMemoryDatabase("ObligatorioDA2")
            // );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ObligatorioDA2.HttpApi", Version = "v1" });
            });
        }

        private void LoadApplicationServices(IServiceCollection services)
        {
            const string contractAssemblyName = "ObligatorioDA2.Application.Contracts";
            Assembly contractAssembly = Assembly.Load(contractAssemblyName);
            // get all interfaces from this assembly
            IEnumerable<Type> interfaces = contractAssembly.GetTypes().Where(t => t.IsInterface);

            // remove '.Contracts' from name
            List<string> sections = contractAssemblyName.Split(".").ToList();
            sections.RemoveAt(sections.Count - 1);

            // get implementing assembly (ObligatorioDA2.Application)
            string implementingAssemblyName = string.Join(".", sections);
            Assembly implementingAssembly = Assembly.Load(implementingAssemblyName);

            // for each contract
            foreach (Type interf in interfaces)
            {
                // get implementation of that contract
                Type type = implementingAssembly.GetTypes().First(impl => interf.IsAssignableFrom(impl));
                // add service implementation to the ioc container
                services.AddScoped(interf, type);
            }
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
