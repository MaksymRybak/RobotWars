using RobotWars.Core.Models.Interfaces;
using RobotWars.DTO;

namespace RobotWars
{
    public interface ICompetitionBootstrap
    {
        void Start(InputCompetitionDataDTO competitionData);
    }

    public class CompetitionBootstrap : ICompetitionBootstrap
    {
        private readonly GameConsole _gameConsole;


        public CompetitionBootstrap(IBattleArena battleArena)
        {
            _gameConsole = new GameConsole(battleArena);
        }

        public void Start(InputCompetitionDataDTO competitionData)
        {
            if (competitionData != null)
            {
                _gameConsole.SetUpCompetition();
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
