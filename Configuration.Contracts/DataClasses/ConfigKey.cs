using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCo.ConfigExample.CrossCutting.Configuration.Contracts.DataClasses
{
    public class ConfigKey : ConfigIdentifier
    {
        public static implicit operator ConfigKey(string value)
        {
            return new ConfigKey {Name = value};
        }
    }
}
