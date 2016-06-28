using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class BattleArena : IBattleArena
    {
        public ArenaCoordinates BottomLeftCoordinates { get; set; }
        public ArenaCoordinates UpperRightCoordinates { get; set; }


        public void SetUpArena(ArenaCoordinates bottomLeftCoordinates, ArenaCoordinates upperRightCoordinates)
        {
            throw new System.NotImplementedException();
        }
    }
}
