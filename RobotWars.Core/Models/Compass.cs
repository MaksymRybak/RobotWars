using RobotWars.Core.Enums;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class Compass : ICompass
    {
        public CompassPoint GetNextLeftPoint(CompassPoint currentPoint)
        {
            CompassPoint result = CompassPoint.N;

            switch (currentPoint)
            {
                case CompassPoint.N:
                    result = CompassPoint.W;
                    break;
                case CompassPoint.E:
                    result = CompassPoint.N;
                    break;
                case CompassPoint.S:
                    result = CompassPoint.E;
                    break;
                case CompassPoint.W:
                    result = CompassPoint.S;
                    break;
            }

            return result;
        }

        public CompassPoint GetNextRightPoint(CompassPoint currentPoint)
        {
            CompassPoint result = CompassPoint.N;

            switch (currentPoint)
            {
                case CompassPoint.N:
                    result = CompassPoint.E;
                    break;
                case CompassPoint.E:
                    result = CompassPoint.S;
                    break;
                case CompassPoint.S:
                    result = CompassPoint.W;
                    break;
                case CompassPoint.W:
                    result = CompassPoint.N;
                    break;
            }

            return result;
        }
    }
}
