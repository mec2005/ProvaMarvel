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
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MarvelContext>(opt => opt.UseInMemoryDatabase(databaseName: "marvel"));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddScoped<ICharacterRepository, CharacterRepository>();

            services.AddTransient<ICharacterService, CharacterService>();
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
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
