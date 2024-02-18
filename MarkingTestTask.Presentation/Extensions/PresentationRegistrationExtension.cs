using MarkingTestTask.Presentation.Mediator;
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
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ProductsViewModel>();
            services.AddSingleton<BoxesViewModel>();
            services.AddSingleton<PalletsViewModel>();

            services.AddSingleton<ICodesImportMediator, CodesImportMediator>();
        }
    }
}
