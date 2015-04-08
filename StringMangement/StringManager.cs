using System.Collections.Generic;
using System.Linq;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts;
using CoCo.ConfigExample.Logic.StringManagement.Contracts;

namespace CoCo.ConfigExample.Logic.StringMangement
{
    public class StringManager : IStringManager
    {
        private readonly IConfigurator _configurator;

        public StringManager(IConfigurator configurator)
        {
            _configurator = configurator;
        }

        public IEnumerable<string> GetAll()
        {
            var strings = new[] {"Foo", "Bar", "Blubb"};

            var toUpper = _configurator.Get<bool>(Config.Areas.Transforms, Config.Keys.ToUpper);

            if (toUpper)
            {
                return strings.Select(s => s.ToUpper());
            }
            else
            {
                return strings.Select(s => s.ToLower());
            }
        }
    }
}
