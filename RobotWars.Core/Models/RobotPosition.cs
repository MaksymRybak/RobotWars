using RobotWars.Core.Enums;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class RobotPosition : IRobotPosition
    {
        public IArenaCoordinates Location { get; set; }
        public HeadingDirection Heading { get; set; }
    }
}
