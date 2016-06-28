using System.Collections.Generic;
using RobotWars.Core.Models;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars
{
    public class GameConsole
    {
        private readonly IBattleArena _battleArena;
        public NavigationSystem NavigationSystem { get; set; }
        public ICollection<Robot> Robots { get; set; }

        public GameConsole(IBattleArena battleArena)
        {
            _battleArena = battleArena;
        }

        public void SetUpCompetition()
        {
            
        }

        public void StartCompetition()
        {

        }

        public void EndCompetition()
        {

        }

        public void VisualizeCompetitionResults()
        {
            
        }
    }
}
