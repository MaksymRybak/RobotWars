namespace RobotWars.Core.Models.Interfaces
{
    public interface IBattleArena
    {
        void SetUpArena(IArenaCoordinates bottomLeftCoordinates, IArenaCoordinates upperRightCoordinates);
    }
}
