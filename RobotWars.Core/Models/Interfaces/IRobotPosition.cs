using RobotWars.Core.Enums;

namespace RobotWars.Core.Models.Interfaces
{
    public interface IRobotPosition
    {
        IArenaCoordinates Location { get; set; }
        HeadingDirection Heading { get; set; }
    }
}
