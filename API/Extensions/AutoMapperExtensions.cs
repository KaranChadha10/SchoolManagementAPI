using API.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
