using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyShopWebService.Infrastructure;
using Ninject;
using ShopManager.Implement.Infrastructure;

namespace MyShopWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AutofacServiceRootProvider provider = new AutofacServiceRootProvider();

            ShopManager.Implement.Bootstrapper.PrepairKernel(provider);

            CreateHostBuilder(args, provider.ContainerBuilder).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, ContainerBuilder containerBuilder) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacCustomFactory(containerBuilder))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
