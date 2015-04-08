using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts.DataClasses;

namespace CoCo.ConfigExample.Logic.StringMangement.Config
{
    internal static class Keys
    {
        public static ConfigKey ToUpper { get { return "toupper"; } }
    }
}
