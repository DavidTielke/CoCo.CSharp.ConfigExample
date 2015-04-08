using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.ConfigExample.Logic.StringManagement.Contracts;
using CoCo.ConfigExample.Logic.StringMangement;
using Ninject.Modules;

namespace DependencyInjection.Logic
{
    class StringManagementMappings : NinjectModule
    {
        public override void Load()
        {
            Bind<IStringManager>().To<StringManager>();
        }
    }
}
