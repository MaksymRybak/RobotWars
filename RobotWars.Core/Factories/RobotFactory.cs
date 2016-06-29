using System.Collections.Generic;
using RobotWars.Core.Enums;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Factories
{
    public class RobotFactory : IRobotFactory
    {
        public IRobot GetRobot()
        {
            return new Robot
            {
                Position = GetRobotPosition(),
                BattleMoves = new List<RobotMove>()
            };
        }

        public IRobotPosition GetRobotPosition()
        {
            return new RobotPosition();
        }
    }
}
