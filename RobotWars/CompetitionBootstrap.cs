using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models.Interfaces;
using RobotWars.DTO;

namespace RobotWars
{
    public interface ICompetitionBootstrap
    {
        void Start(InputCompetitionDataDTO competitionData);
    }

    /// <summary>
    /// Actor that uses the game console
    /// </summary>
    public class CompetitionBootstrap : ICompetitionBootstrap
    {
        private readonly GameConsole _gameConsole;


        public CompetitionBootstrap(IBattleArena battleArena, INavigationSystem navigationSystem, IRobotFactory robotFactory, IArenaFactory arenaFactory)
        {
            _gameConsole = new GameConsole(battleArena, navigationSystem, robotFactory, arenaFactory);
        }

        public void Start(InputCompetitionDataDTO competitionData)
        {
            if (competitionData != null)
            {
                _gameConsole.SetUpCompetition(competitionData);
                _gameConsole.StartCompetition();
                _gameConsole.EndCompetition();
                _gameConsole.VisualizeCompetitionResults();
            }
            else
            {
                // TODO: log
            }
        }        
    }
}
