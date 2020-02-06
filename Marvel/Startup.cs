using Marvel.Data;
using Marvel.Domain.Interfaces;
using Marvel.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Marvel.Data.Repository;
using Microsoft.OpenApi.Models;

namespace Marvel
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
            // Cria um banco de dados em memória
            services.AddDbContext<MarvelContext>(opt => opt.UseInMemoryDatabase(databaseName: "marvel"));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddScoped<ICharacterRepository, CharacterRepository>();

            services.AddTransient<ICharacterService, CharacterService>();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Marvel Test Api", Version = "v1" });
            });

            services.AddMvcCore().AddApiExplorer();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
                       
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marvel Test Api");
            });

            app.UseMvc();
        }
    }
}
