using LightInject;
using RobotWars.Core.Factories.Interfaces;

namespace RobotWars.Core.Factories
{
    public class Factory : IFactory
    {
        protected readonly ServiceContainer _serviceContainer;

        public Factory(ServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }
    }
}
