using System;
using System.Runtime.Serialization;

namespace CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts.Exceptions
{
    [Serializable]
    public class ConfigurationStorageException : Exception
    {
        public ConfigurationStorageException()
        {
        }

        public ConfigurationStorageException(string message) : base(message)
        {
        }

        public ConfigurationStorageException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ConfigurationStorageException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}