using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class BattleArena : IBattleArena
    {
        public IArenaCoordinates BottomLeftCoordinates { get; set; }
        public IArenaCoordinates UpperRightCoordinates { get; set; }

        public void SetUpArena(IArenaCoordinates bottomLeftCoordinates, IArenaCoordinates upperRightCoordinates)
        {
            BottomLeftCoordinates = bottomLeftCoordinates;
            UpperRightCoordinates = upperRightCoordinates;
        }
    }
}
