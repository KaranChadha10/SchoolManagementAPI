using API.IRepositories;
using API.IServices;
using API.Repositories;
using API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCoreComponents(this IServiceCollection services)
        {
            #region  Repositories
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion


            #region  Services
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<IUserService, UserService>();
            #endregion


            return services;

        }
    }
}
