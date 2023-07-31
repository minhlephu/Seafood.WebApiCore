using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));
        }
    }
}
