using System.Collections.Generic;
using RobotWars.Core.Enums;

namespace RobotWars.Core.Models.Interfaces
{
    public interface IRobot
    {
        int Id { get; set; }
        IRobotPosition Position { get; set; }
        IList<RobotMove> BattleMoves { get; set; }
    }
}
