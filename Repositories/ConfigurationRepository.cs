using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Contracts;

namespace Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public ConfigurationRepository(IConfigurator)
        {
            
        }

        public void Store(IEnumerable<ConfigEntity> entities)
        {
            
        }

        public IEnumerable<ConfigEntity> Load()
        {

        }
    }
}
