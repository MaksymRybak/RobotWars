using System.Collections.Generic;
using RobotWars.Core.Enums;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class Robot : IRobot
    {
        public int Id { get; set; }
        public IRobotPosition Position { get; set; }
        public IList<RobotMove> BattleMoves { get; set; }
    }
}
