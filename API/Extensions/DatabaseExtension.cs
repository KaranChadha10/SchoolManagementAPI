using API.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class DatabaseExtension 
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
