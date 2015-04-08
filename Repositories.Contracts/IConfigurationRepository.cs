using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IConfigurationRepository
    {
        void Store(IEnumerable<ConfigEntity> entities);

        IEnumerable<ConfigEntity> Load();
    }

    public class ConfigEntity
    {
        public ConfigEntity(string area, string key, string value, string type, bool persist)
        {
            Value = value;
            Type = type;
            Key = key;
            Area = area;
            Persist = persist;
        }

        public string Type { get; private set; }
        public string Value { get; private set; }
        public string Key { get; private set; }
        public string Area { get; private set; }
        public bool Persist { get; private set; }
    }
}
