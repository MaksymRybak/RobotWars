using System;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models.Interfaces;
using RobotWars.Core.System;
using RobotWars.Core.System.Logging;
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
        private readonly ILogWriter _logWriter;
        private readonly IConsoleWrapper _console;
        private readonly GameConsole _gameConsole;

        public CompetitionBootstrap(IBattleArena battleArena, INavigationSystem navigationSystem, 
            IRobotFactory robotFactory, IArenaFactory arenaFactory, IConsoleWrapper console, ILogWriter logWriter)
        {
            _logWriter = logWriter;
            _console = console;
            _gameConsole = new GameConsole(battleArena, navigationSystem, robotFactory, arenaFactory, console, logWriter);
        }

        public void Start(InputCompetitionDataDTO competitionData)
        {
            if (competitionData != null)
            {
                try
                {
                    _gameConsole.SetUpCompetition(competitionData);
                    _gameConsole.StartCompetition();
                    _gameConsole.EndCompetition();
                    _gameConsole.VisualizeCompetitionResults();
                }
                catch (Exception ex)
                {
                    _console.WriteLine("Error. See logs for details.");
                    _logWriter.LogError("Error in competition process", ex);
                }
            }
            else
            {
                _logWriter.LogErrorFormat("Cannot start competition, input data is null");
            }
        }        
    }
}
