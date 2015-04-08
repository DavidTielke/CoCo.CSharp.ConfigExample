using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCo.ConfigExample.CrossCutting.Configuration.Contracts.DataClasses
{
    public class ConfigArea : ConfigIdentifier
    {
        public static implicit operator ConfigArea(string value)
        {
            return new ConfigArea { Name = value };
        }
    }
}
