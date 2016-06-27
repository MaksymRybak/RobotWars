using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class BattleArena : IBattleArena
    {
        public ArenaCoordinates BottomLeftCoordinates { get; set; }
        public ArenaCoordinates UpperRightCoordinates { get; set; }
    }
}
