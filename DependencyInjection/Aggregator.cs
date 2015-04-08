using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.CrossCutting;
using DependencyInjection.Logic;
using Ninject.Modules;

namespace DependencyInjection
{
    public static class Aggregator
    {
        public static NinjectModule[] Mappings
        {
            get
            {
                return new NinjectModule[]
                {
                    new ConfigurationMappings(), 
                    new ConfigurationStorageMappings(), 
                    new StringManagementMappings(), 
                };
            }
        }
    }
}
