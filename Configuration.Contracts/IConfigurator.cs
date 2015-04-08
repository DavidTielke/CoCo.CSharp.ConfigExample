using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts.DataClasses;

namespace CoCo.ConfigExample.CrossCutting.Configuration.Contracts
{
    public interface IConfigurator
    {
        T Get<T>(ConfigArea area, ConfigKey key);
        void Set(ConfigArea area, ConfigKey key, object value, bool persist = false);
        void Load();
        void Store();
    }
}
