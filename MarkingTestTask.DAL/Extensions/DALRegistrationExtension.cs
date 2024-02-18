using MarkingTestTask.DAL.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MarkingTestTask.DAL.Extensions
{
    public static class DALRegistrationExtension
    {
        public static void RegisterDALDependencies(this IServiceCollection services)
        {
            services.AddSingleton<MarkingTestTaskDBContext>();
            services.AddSingleton<IProductModelRepository, ProductModelRepository>();
            services.AddSingleton<IBoxModelRepository, BoxModelRepository>();
            services.AddSingleton<IPalletModelRepository, PalletModelRepository>();
        }
    }
}
