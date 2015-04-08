using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.ConfigExample.CrossCutting.Configuration;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts;
using Ninject.Modules;

namespace DependencyInjection.CrossCutting
{
    class ConfigurationMappings : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigurator>().To<Configurator>().InSingletonScope();
        }
    }
}
