using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR_Management.Application
{
    public static class ApplicationServicesRegistration
    {
        /// <summary>
        /// add current project services
        /// </summary>
        /// <param name="services">extension</param>
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            // use this for one mapper profile
            //services.AddAutoMapper(typeof(Profiles.MappingProfile));
            // Get all mappers profiles of current project
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
