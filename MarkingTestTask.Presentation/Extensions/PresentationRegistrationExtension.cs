using MarkingTestTask.Presentation.MVVM;
using Microsoft.Extensions.DependencyInjection;

namespace MarkingTestTask.Presentation.Extensions
{
    public static class PresentationRegistrationExtension
    {
        public static void RegisterPresentationDependencies(this IServiceCollection services)
        {
            services.AddSingleton<App>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<CurrentTaskViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<BoxesViewModel>();
            services.AddTransient<PalletsViewModel>();
        }
    }
}
