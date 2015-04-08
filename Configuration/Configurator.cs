using System;
using System.Collections.Generic;
using System.Linq;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts.DataClasses;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts.Exceptions;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts;
using CoCo.ConfigExample.CrossCutting.ConfigurationStorage.Contracts.DataClasses;
using KeyNotFoundException = CoCo.ConfigExample.CrossCutting.Configuration.Contracts.Exceptions.KeyNotFoundException;

namespace CoCo.ConfigExample.CrossCutting.Configuration
{
    public class Configurator : IConfigurator
    {
        private List<ConfigEntry> _entries;
        private readonly IConfigurationStore _configurationStore;

        public Configurator(IConfigurationStore configurationStore)
        {
            if (configurationStore == null)
            {
                throw new ArgumentNullException("configurationStore");
            }

            _configurationStore = configurationStore;

            _entries = new List<ConfigEntry>();
        }

        public T Get<T>(ConfigArea area, ConfigKey key)
        {
            if (area == null)
            {
                throw new ArgumentNullException("area");
            }

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            var areaExist = AreaExist(area);
            if (!areaExist)
            {
                throw new AreaNotFoundException("Can't find area " + area.Name);
            }

            var keyExist = EntryExist(area, key);
            if (!keyExist)
            {
                var message = String.Format("Can't find key {0} ind area {1}", key.Name, area.Name);
                throw new KeyNotFoundException(message);
            }

            try
            {
                var entry = GetEntry(area, key);

                var typeToReturn = typeof(T);
                var typeOfValue = entry.Value.GetType();
                var typesAreEqual = typeToReturn == typeOfValue;
                if (!typesAreEqual)
                {
                    var message = String.Format("Can't convert source type {0} to requested type {1}", typeOfValue,
                        typeToReturn);
                    throw new InvalidTypeException(message);
                }

                return (T)(object)entry.Value;
            }
            catch (InvalidTypeException)
            {
                throw;
            }
            catch (Exception e)
            {
                var message = String.Format("Can't get a value for {0} in area {1}", area.Name, key.Name);
                throw new ConfigurationException(message, e);
            }
        }

        public void Set(ConfigArea area, ConfigKey key, object value, bool persist = false)
        {
            if (area == null)
            {
                throw new ArgumentNullException("area");
            }

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            try
            {
                var entryExist = EntryExist(area, key);
                if (entryExist)
                {
                    var entry = GetEntry(area, key);
                    entry.Value = value;
                    entry.Persist = persist;
                }
                else
                {
                    var entry = new ConfigEntry(area.Name, key.Name, value, persist);
                    _entries.Add(entry);
                }
            }
            catch (Exception e)
            {
                var message = String.Format("Error setting value {0} for key {1} in area {2} ({3})",
                    value, key.Name, area.Name, persist ? "persistent" : "non-persistent");
                throw new ConfigurationException(message, e);
            }
        }

        public void Load()
        {
            try
            {
                var entities = _configurationStore.Load();
                var entries = new List<ConfigEntry>();

                foreach (var entity in entities)
                {
                    var entry = new ConfigEntry(entity.Area, entity.Key, null, true);

                    try
                    {
                        entry.Value = Convert.ChangeType(entity.Value, Type.GetType(entity.Type));
                    }
                    catch (InvalidCastException e)
                    {
                        var message = String.Format("Error converting key {0} in area {1} on Load", entity.Key, entity.Area);
                        throw new ConfigurationException(message, e);
                    }

                    entries.Add(entry);
                }
                _entries = entries;
            }
            catch (ConfigurationException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ConfigurationException("Error on loading configuration values from store", e);
            }
        }

        public void Store()
        {
            try
            {
                var entities = _entries
                    .Where(e => e.Persist)
                    .Select(e => new ConfigEntity(e.Area, e.Key, e.Value.ToString(), e.Value.GetType().FullName));
                _configurationStore.Store(entities);
            }
            catch (Exception e)
            {
                throw new ConfigurationException("Error on storing configuration values", e);
            }
        }

        private bool AreaExist(ConfigArea area)
        {
            var areaExist = _entries.Any(e => e.Area == area.Name);
            return areaExist;
        }

        private ConfigEntry GetEntry(ConfigArea area, ConfigKey key)
        {
            var entry = _entries.Single(e => e.Area == area.Name && e.Key == key.Name);
            return entry;
        }

        private bool EntryExist(ConfigArea area, ConfigKey key)
        {
            var entryExist = _entries.Any(e => e.Area == area.Name && e.Key == key.Name);
            return entryExist;
        }
    }
}
