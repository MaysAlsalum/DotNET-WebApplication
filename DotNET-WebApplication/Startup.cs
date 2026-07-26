using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNET_WebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly ILogger<Startup> _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register services
            services.AddSingleton<IProductService, ProductService>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Use custom middleware
            app.UseMiddleware<CustomMiddleware>();

            // Use built-in logging
            _logger.LogInformation("Application Started!");

            // Use routing
            app.UseRouting();

            // Use endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
