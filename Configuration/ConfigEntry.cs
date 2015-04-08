using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts.DataClasses;

namespace CoCo.ConfigExample.CrossCutting.Configuration
{
    internal class ConfigEntry
    {
        public ConfigEntry(string area, string key, object value, bool persist)
        {
            Value = value;
            Persist = persist;
            Key = key;
            Area = area;
        }

        public object Value { get; internal set; }
        public string Key { get; private set; }
        public string Area { get; private set; }
        public bool Persist { get; internal set; }
    }
}
