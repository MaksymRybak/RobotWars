using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Factories.Interfaces
{
    public interface IRobotFactory
    {
        IRobot GetRobot();
        IRobotPosition GetRobotPosition();
    }
}
