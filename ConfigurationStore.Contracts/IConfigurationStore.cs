using System.Collections.Generic;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts.DataClasses;

namespace CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts
{
    public interface IConfigurationStore
    {
        void Store(IEnumerable<ConfigEntity> entities);

        IEnumerable<ConfigEntity> Load();
    }
}
