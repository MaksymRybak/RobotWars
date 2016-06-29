using LightInject;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Factories
{
    public class ArenaFactory : Factory, IArenaFactory
    {
        public ArenaFactory(ServiceContainer serviceContainer) : base(serviceContainer)
        {
        }

        public IArenaCoordinates GetArenaCoordinates()
        {
            return _serviceContainer.GetInstance<IArenaCoordinates>();
        }
    }
}
