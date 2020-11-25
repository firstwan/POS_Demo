using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS_Demo.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using POS_Demo.Services;
using POS_Demo.Domain.Repositories;
using POS_Demo.OrderWindow;

namespace POS_Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            // Get environment
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{environment}.json", optional: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();


            // In memory database build data
            var dbContext = ServiceProvider.GetRequiredService<AppDBContext>();
            DataGenerator.Initialize(dbContext);

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = Configuration["DatabaseConnection"];
            services.AddDbContext<AppDBContext>(options =>
              options.UseInMemoryDatabase("PosDemo"));


            services.AddTransient<MainWindow>();
            services.AddTransient<BundleRepo>();
            services.AddTransient<CategoriesRepo>();
            services.AddTransient<OrdersRepo>();
            services.AddTransient<ProductsRepo>();


            services.AddTransient<OrderViewModel>();
        }
    }
}
