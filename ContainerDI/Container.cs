using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LightInject;
using ClassLibraryCreditCalculate; 

namespace ContainerDI
{
    public class Container
    {
        private ServiceContainer _serviceContainer;

        public Container()
        {
            _serviceContainer = new ServiceContainer();

            _serviceContainer.Register<ICreditInfo, CreditInfo>();
        }

        public ServiceContainer GetServiceContainer { get { return _serviceContainer; } }
    }
}
