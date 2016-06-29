using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Factories.Interfaces
{
    public interface IArenaFactory
    {
        IArenaCoordinates GetArenaCoordinates();
    }
}
