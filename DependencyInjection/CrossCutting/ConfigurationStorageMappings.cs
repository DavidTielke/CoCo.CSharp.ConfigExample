using CoCo.ConfigExample.CrossCutting.Configuration;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts;
using Ninject.Modules;

namespace DependencyInjection.CrossCutting
{
    class ConfigurationStorageMappings : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigurationStore>().To<JsonConfigurationStore>().WithConstructorArgument("pathToJsonFile","config.json");
        }
    }
}