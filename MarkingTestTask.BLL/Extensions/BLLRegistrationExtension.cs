using MarkingTestTask.BLL.Contracts;
using MarkingTestTask.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MarkingTestTask.BLL.Extensions
{
    public static class BLLRegistrationExtension
    {
        public static void RegisterBLLDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMissionInfoRetrievalService, MissionInfoRetrievalService>();
            services.AddSingleton<ICodeImportService, CodeImportService>();
            services.AddSingleton<IBoxPalletPopulationService, BoxPalletPopulationService>();
            services.AddSingleton<ILayoutService, LayoutService>();

            services.RegisterAutomapperProfiles();
        }
    }
}
