using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace MarkingTestTask.BLL.Extensions
{
    public static class AutoMapperRegistrationExtensions
    {
        public static void RegisterAutomapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
