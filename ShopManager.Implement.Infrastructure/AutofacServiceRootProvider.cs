using System.Collections.Generic;
using Autofac;
using ShopManager.Core.Management;

namespace ShopManager.Implement.Infrastructure
{
    public sealed class AutofacServiceRootProvider : IServiceRootProvider
    {
        private readonly ContainerBuilder _containerBuilder = new ContainerBuilder();
        private IContainer _container;


        public ContainerBuilder ContainerBuilder => _containerBuilder;

        public void AsSingleton<TAbstraction, TImplementation>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction
        {
            _containerBuilder.RegisterType<TImplementation>().As<TAbstraction>().SingleInstance();
        }

        public void AsSingleton<TAbstraction, TImplementation, TImplementation2>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction
            where TImplementation2 : class, TImplementation
        {
            _containerBuilder.RegisterType<TImplementation2>().As<TImplementation>().As<TAbstraction>().SingleInstance();
        }

        // ok
        public void AsTransient<TAbstraction, TImplementation>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction
        {
            _containerBuilder.RegisterType<TImplementation>().As<TAbstraction>().ExternallyOwned();
        }

        public void Start()
        {
            _container = _containerBuilder.Build();
        }
    }
}