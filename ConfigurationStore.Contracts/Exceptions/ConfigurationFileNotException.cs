using System;
using System.Runtime.Serialization;

namespace CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts.Exceptions
{
    [Serializable]
    public class ConfigurationFileNotException : Exception
    {
        public ConfigurationFileNotException()
        {
        }

        public ConfigurationFileNotException(string message) : base(message)
        {
        }

        public ConfigurationFileNotException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ConfigurationFileNotException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}