using System.Collections.Generic;
using System.Linq;
using RobotWars.Core.Models.Interfaces;
using RobotWars.Core.System;

namespace RobotWars.Core.Models
{
    public class BattleArena : IBattleArena
    {
        private readonly IConsoleWrapper _console;
        private IList<IRobot> _robots;

        public IArenaCoordinates BottomLeftCoordinates { get; set; }
        public IArenaCoordinates UpperRightCoordinates { get; set; }        

        public BattleArena(IConsoleWrapper console)
        {
            _console = console;
            _robots = new List<IRobot>();
        }

        public void SetUpArena(IArenaCoordinates bottomLeftCoordinates, IArenaCoordinates upperRightCoordinates)
        {
            BottomLeftCoordinates = bottomLeftCoordinates;
            UpperRightCoordinates = upperRightCoordinates;
        }

        public void DeployRobots(IList<IRobot> robotsToDeploy)
        {
            if (robotsToDeploy != null && robotsToDeploy.Count > 0)
            {
                robotsToDeploy.ToList().ForEach(robot =>
                {
                    robot.BattleArena = this;
                    _robots.Add(robot);
                });
            }
        }

        public void PrintRobotsPositions()
        {
            _console.WriteLine(">>> Competition result");
            if (_robots != null && _robots.Count > 0)
            {
                _console.WriteLine(">>> Robots positions:");
                _robots.ToList().ForEach(robot => _console.WriteLine(">>> Robot # {0}: {1} {2} {3}", robot.Id, robot.Position.Location.X, 
                    robot.Position.Location.Y, robot.Position.Heading));                
            }
        }

        public IRobot GetRobotById(int idRobot)
        {
            return _robots.FirstOrDefault(r => r.Id == idRobot);
        }
    }
}
