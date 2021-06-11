using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NationalParkSystem.Models;
using NationalParkSystem.Helpers;
using NationalParkSystem.Services;

namespace NationalParkSystem
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        // public IConfiguration Configuration { get; } this property must be private with user registration

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsProduction())
                services.AddDbContext<DataContext>(); // these may need to be revised; see tutorial
            else
                services.AddDbContext<DataContext, SqliteDataContext>(); // these may need to be revised; see tutorial
        
            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<AppSettings>(_configuration.GetSection("AppSettings")); // configures app to grab secret from appsettings.json
            services.AddScoped<IUserService, UserService>();
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            dataContext.Database.Migrate();

            // app.UseHttpsRedirection();

            app.UseRouting();

            // enables cors policy
            app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            
            // a global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // jwt authentication middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}