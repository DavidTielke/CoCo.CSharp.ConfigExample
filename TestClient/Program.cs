using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts;
using CoCo.ConfigExample.CrossCutting.Configuration.Contracts.DataClasses;
using CoCo.ConfigExample.Logic.StringManagement.Contracts;
using DependencyInjection;
using Ninject;

namespace TestClient
{
    class Program
    {

        static void Main(string[] args)
        {
            // Create Kernel and initialize with mappings
            var kernel = new StandardKernel(Aggregator.Mappings);

            // Get configurator and load initialy
            var configurator = kernel.Get<IConfigurator>();
            configurator.Load();

            // Do some logic stuff
            var manager = kernel.Get<IStringManager>();
            manager.GetAll().ToList().ForEach(s => Console.WriteLine(s));

            Console.ReadKey();
        }
    }
}
