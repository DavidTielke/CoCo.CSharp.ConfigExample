using System.Collections.Generic;

namespace CoCo.ConfigExample.Logic.StringManagement.Contracts
{
    public interface IStringManager
    {
        IEnumerable<string> GetAll();
    }
}
