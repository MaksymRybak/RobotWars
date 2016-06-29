using System.Collections.Generic;
using LightInject;
using RobotWars.Core.Enums;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Factories
{
    public class RobotFactory : Factory, IRobotFactory
    {
        public RobotFactory(ServiceContainer serviceContainer)
            : base(serviceContainer)
        {
        }

        public IRobot GetRobot()
        {
            var robot = _serviceContainer.GetInstance<IRobot>();
            robot.Position = GetRobotPosition();
            robot.BattleMoves = new List<RobotMove>();
            return robot;
        }

        public IRobotPosition GetRobotPosition()
        {
            return _serviceContainer.GetInstance<IRobotPosition>();
        }
    }
}
