using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MyShopWebService.Infrastructure
{
    public class AutofacCustomFactory : IServiceProviderFactory<ContainerBuilder>
    {
        /*private readonly Action<ContainerBuilder> _configurationAction;*/
        private readonly ContainerBuilder _containerBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProviderFactory"/> class.
        /// </summary>
        /// <param name="configurationAction">Action on a <see cref="ContainerBuilder"/> that adds component registrations to the conatiner.</param>
        public AutofacCustomFactory(ContainerBuilder containerBuilder/*, Action<ContainerBuilder> configurationAction = null*/)
        {
            /*_configurationAction = configurationAction ?? (builder => { });*/
        }

        /// <summary>
        /// Creates a container builder from an <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The collection of services.</param>
        /// <returns>A container builder that can be used to create an <see cref="IServiceProvider" />.</returns>
        public ContainerBuilder CreateBuilder(IServiceCollection services)
        {
            //var builder = new ContainerBuilder();
            var builder = _containerBuilder;

            builder.Populate(services);

            //_configurationAction(builder);

            return builder;
        }

        /// <summary>
        /// Creates an <see cref="IServiceProvider" /> from the container builder.
        /// </summary>
        /// <param name="containerBuilder">The container builder.</param>
        /// <returns>An <see cref="IServiceProvider" />.</returns>
        public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
        {
            if (containerBuilder == null) throw new ArgumentNullException(nameof(containerBuilder));

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}