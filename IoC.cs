using Microsoft.Extensions.DependencyInjection;
using DevExpress.Mvvm.POCO;
using SEW.ViewModels;
using SEW.Services;

namespace SEW
{
    public static class Ioc
    {
        static readonly ServiceProvider provider;

        static Ioc()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainVM>();
            services.AddSingleton<RememberVM>();
            services.AddSingleton<WordSearchVM>();
            services.AddSingleton<SettingsVM>();
            services.AddSingleton<CategoryVM>();
            services.AddSingleton<WordVM>();
            services.AddSingleton<ExampleVM>();

            services.AddSingleton<PageService>();

            provider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => provider.GetRequiredService<T>();
    }
}
