using System.Collections.Generic;

namespace RobotWars.Core.Models.Interfaces
{
    public interface IBattleArena
    {
        IArenaCoordinates BottomLeftCoordinates { get; set; }
        IArenaCoordinates UpperRightCoordinates { get;set; }

        void SetUpArena(IArenaCoordinates bottomLeftCoordinates, IArenaCoordinates upperRightCoordinates);
        void DeployRobots(IList<IRobot> robotsToDeploy);
        void PrintRobotsPositions();

        IRobot GetRobotById(int idRobot);
    }
}
