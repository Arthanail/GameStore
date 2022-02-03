using System;
using API.Services;
using Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(options => options.
                UseSqlServer(Configuration["ConnectionString"], b
                => b.MigrationsAssembly("API")));
            
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddSingleton<IMessageBusClient, MessageBusClient>();
            
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddControllers();
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