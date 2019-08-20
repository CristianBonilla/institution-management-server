using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Institution.Domain;
using Institution.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Institution.API
{
    public class AutofacProvider
    {
        public static AutofacServiceProvider Provider(IServiceCollection services)
        {
            IContainer container = Container(services);
            AutofacServiceProvider serviceProvider = new AutofacServiceProvider(container);

            return serviceProvider;
        }

        private static IContainer Container(IServiceCollection services)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterGeneric(typeof(Context<>))
                .As(typeof(IContext<>));
            containerBuilder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>));
            containerBuilder.RegisterType<AlumnoService>()
                .As<IAlumnoService>();

            IContainer container = containerBuilder.Build();

            return container;
        }
    }
}
