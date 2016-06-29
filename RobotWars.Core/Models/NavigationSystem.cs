using RobotWars.Core.Enums;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class NavigationSystem : INavigationSystem
    {
        private IBattleArena _battleArena;

        public void ConnectNavigationSystemToBattleArena(IBattleArena battleArena)
        {
            _battleArena = battleArena;
        }

        public void MoveRobot(int idRobot, RobotMove move)
        {
            var robotToMove = _battleArena.GetRobotById(idRobot);
            if (robotToMove != null)
                robotToMove.PerformBattleMove(move);
        }
    }
}
