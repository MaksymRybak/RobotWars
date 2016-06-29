using RobotWars.Core.Enums;

namespace RobotWars.Core.Models.Interfaces
{
    public interface ICompass
    {
        CompassPoint GetNextLeftPoint(CompassPoint currentPoint);
        CompassPoint GetNextRightPoint(CompassPoint currentPoint);
    }
}
