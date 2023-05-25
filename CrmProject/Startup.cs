using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrmProject.Repositories;
//using CrmProject.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CrmProject
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
            services.AddControllers();

            services.AddScoped<IRegisterRepository, RegisterRepository>();

            //services.AddDbContext<YourDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection;")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Other middleware configurations

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
            }
    }
}
