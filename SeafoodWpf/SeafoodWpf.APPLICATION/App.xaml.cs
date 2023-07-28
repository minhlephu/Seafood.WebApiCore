using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeafoodWpf.APPLICATION.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SeafoodWpf.APPLICATION.View;
using SeafoodWpf.BUSINESS.Services;
using SeafoodWpf.APPLICATION.Base;
using SeafoodWpf.APPLICATION.View.CustomUC;

namespace SeafoodWpf.APPLICATION
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddFormFactory<LoginWindow>();
                    //services.AddFormFactory<ControlBarUC>();
                    services.AddTransient<IUserService, UserService>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost?.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
