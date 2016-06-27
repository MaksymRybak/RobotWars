using System.Collections.Generic;
using RobotWars.Core.Models;

namespace RobotWars
{
    public class GameConsole
    {
        public BattleArena Arena { get; set; }
        public NavigationSystem NavigationSystem { get; set; }
        public ICollection<Robot> Robots { get; set; }

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
