using System;
using API.EventProcessing;
using API.Queries;
using API.Services;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(options => options.
                UseSqlServer("Server=DESKTOP-U688BIV;Database=gameStore;Trusted_Connection=True;", b
                => b.MigrationsAssembly("API")));
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameQueries, GameQueries>();
            services.AddSingleton<IMessageBusClient, MessageBusClient>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddControllers();

            services.AddSingleton<IEventProcessor, EventProcessor>();
        }
 
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
 
            app.UseRouting();
 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}