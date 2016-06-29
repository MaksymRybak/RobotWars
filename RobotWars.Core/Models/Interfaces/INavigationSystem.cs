using RobotWars.Core.Enums;

namespace RobotWars.Core.Models.Interfaces
{
    public interface INavigationSystem
    {
        void ConnectNavigationSystemToBattleArena(IBattleArena battleArena);
        void MoveRobot(int idRobot, RobotMove move);
    }
}
