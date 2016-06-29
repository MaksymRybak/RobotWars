using System.Collections.Generic;
using System.Linq;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models.Interfaces;
using RobotWars.Core.System;
using RobotWars.DTO;
using RobotWars.Mappers;

namespace RobotWars
{
    /// <summary>
    /// Facade of the game console
    /// </summary>
    public class GameConsole
    {
        private bool _competitionIsReady;

        private readonly IBattleArena _battleArena;
        private readonly INavigationSystem _navigationSystem;
        private readonly IConsoleWrapper _console;
        private IList<IRobot> _robots;

        private readonly RobotMapper _robotMapper;
        private readonly ArenaMapper _arenaMapper;

        public GameConsole(IBattleArena battleArena, INavigationSystem navigationSystem, IRobotFactory robotFactory, IArenaFactory arenaFactory, IConsoleWrapper console)
        {
            _battleArena = battleArena;
            _navigationSystem = navigationSystem;
            _console = console;

            _robotMapper = new RobotMapper(robotFactory, arenaFactory);
            _arenaMapper = new ArenaMapper(arenaFactory);
        }

        public void SetUpCompetition(InputCompetitionDataDTO competitionData)
        {
            _robots = _robotMapper.FromListRobotDTOToListRobot(competitionData.RobotsToDeploy);
            
            _battleArena.SetUpArena(
                _arenaMapper.FromArenaCoordinatesDTOToArenaCoordinates(competitionData.ArenaBottomLeftCoords),
                _arenaMapper.FromArenaCoordinatesDTOToArenaCoordinates(competitionData.ArenaUpperRightCoords)
             );

            _battleArena.DeployRobots(_robots);

            _navigationSystem.ConnectNavigationSystemToBattleArena(_battleArena);

            _competitionIsReady = true;
        }

        public void StartCompetition()
        {
            if (_competitionIsReady)
            {
                _console.WriteLine(">>> Competition started");
                PerformRobotsMoves();
            }
            else
            {
                // TODO: log
            }
        }        

        public void EndCompetition()
        {
            _console.WriteLine(">>> Competition ended");
            _competitionIsReady = false;
        }

        public void VisualizeCompetitionResults()
        {
            _battleArena.PrintRobotsPositions();
        }

        public void PerformRobotsMoves()
        {
            if (_robots != null && _robots.Count > 0)
            {
                _robots.ToList().ForEach(robot =>
                {
                    _console.WriteLine(">>> Robot # {0} is moving", robot.Id);
                    var robotMoves = robot.BattleMoves;
                    robotMoves.ToList().ForEach(move => _navigationSystem.MoveRobot(robot.Id, move));
                    _console.WriteLine(">>> Robot # {0} finished", robot.Id);
                });
            }
        }
    }
}
