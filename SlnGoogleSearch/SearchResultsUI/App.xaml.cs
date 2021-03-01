using System;
using System.Windows;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using LibSearchResults.Interfaces;

namespace SearchResultsUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;
        public App()
        {
            
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IWebCall, LibSearchResults.WebCall>();
            string sFolderPath = string.Concat(Environment.CurrentDirectory, @"\Logs");
            Directory.CreateDirectory(sFolderPath);
            services.AddScoped<ILogger>(x => new LibSearchResults.Utilities.Logger(sFolderPath));

            string sJsonPath = string.Concat(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")), "parameters.json");
            services.AddScoped<IJsonReader>(x => new LibSearchResults.Utilities.JsonReader(sJsonPath));

            services.AddSingleton<MainWindow>();
        }
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            //base.OnStartup(e);
        }
    }

}
