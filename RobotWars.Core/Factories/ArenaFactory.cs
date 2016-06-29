using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Factories
{
    public class ArenaFactory : IArenaFactory
    {
        public IArenaCoordinates GetArenaCoordinates()
        {
            return new ArenaCoordinates();
        }
    }
}
