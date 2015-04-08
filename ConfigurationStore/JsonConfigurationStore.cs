using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts.DataClasses;
using System.IO;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts.Exceptions;
using Newtonsoft.Json;

namespace CoCo.ConfigExample.CrossCutting.ConfigurationStorage
{
    public class JsonConfigurationStore : IConfigurationStore
    {
        private readonly string _pathToJsonFile;

        public JsonConfigurationStore(string pathToJsonFile)
        {
            _pathToJsonFile = pathToJsonFile;
        }

        public void Store(IEnumerable<ConfigEntity> entities)
        {
            try
            {
                var fileExist = File.Exists(_pathToJsonFile);
                if (fileExist)
                {
                    File.Delete(_pathToJsonFile);
                }

                var jsonSerializer = new JsonSerializer();

                using (StreamWriter streamWriter = new StreamWriter(_pathToJsonFile))
                {
                    using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonSerializer.Serialize(jsonWriter, entities);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ConfigurationStorageException("Error on storing configuration data", e);
            }
        }

        public IEnumerable<ConfigEntity> Load()
        {
            try
            {
                var fileExist = File.Exists(_pathToJsonFile);
                if (!fileExist)
                {
                    throw new ConfigurationFileNotException("Can't find the configuration file at" + _pathToJsonFile);
                }

                var jsonSerializer = new JsonSerializer();

                using (var streamReader = new StreamReader(_pathToJsonFile))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var entities = jsonSerializer.Deserialize<IEnumerable<ConfigEntity>>(jsonReader);
                        return entities;
                    }
                }
            }
            catch (ConfigurationFileNotException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ConfigurationStorageException("Error on loading configuration", e);
            }
        }
    }
}
