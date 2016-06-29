using System.Collections.Generic;
using RobotWars.Core.Enums;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class Robot : IRobot
    {
        private readonly ICompass _compass;

        public int Id { get; set; }
        public IRobotPosition Position { get; set; }
        public IBattleArena BattleArena { get; set; }
        public IList<RobotMove> BattleMoves { get; set; }

        public Robot(ICompass compass)
        {
            _compass = compass;
        }

        public void PerformBattleMove(RobotMove move)
        {
            switch (move)
            {
                case RobotMove.L:
                    Position.Heading = _compass.GetNextLeftPoint(Position.Heading);
                    break;
                case RobotMove.R:
                    Position.Heading = _compass.GetNextRightPoint(Position.Heading);
                    break;
                case RobotMove.M:
                    UpdateLocationAfterForwardMove();
                    break;
            }
        }

        public void UpdateLocationAfterForwardMove()
        {
            switch (Position.Heading)
            {
                case CompassPoint.N:
                    Position.Location.Y++; 
                    break;
                case CompassPoint.E:
                    Position.Location.X++; 
                    break;
                case CompassPoint.S:
                    Position.Location.Y--;
                    break;
                case CompassPoint.W:
                    Position.Location.X--;
                    break;
            }

            // cannot go out of the battle arena
            if (Position.Location.X < BattleArena.BottomLeftCoordinates.X) Position.Location.X = BattleArena.BottomLeftCoordinates.X;
            if (Position.Location.Y < BattleArena.BottomLeftCoordinates.Y) Position.Location.Y = BattleArena.BottomLeftCoordinates.Y;
            if (Position.Location.X > BattleArena.UpperRightCoordinates.X) Position.Location.X = BattleArena.UpperRightCoordinates.X;
            if (Position.Location.Y > BattleArena.UpperRightCoordinates.Y) Position.Location.Y = BattleArena.UpperRightCoordinates.Y;
        }
    }
}
