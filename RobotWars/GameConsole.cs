using System.Collections.Generic;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models.Interfaces;
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
        private IList<IRobot> _robots;

        private readonly RobotMapper _robotMapper;
        private readonly ArenaMapper _arenaMapper;

        public GameConsole(IBattleArena battleArena, INavigationSystem navigationSystem, IRobotFactory robotFactory, IArenaFactory arenaFactory)
        {
            _battleArena = battleArena;
            _navigationSystem = navigationSystem;

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

            _competitionIsReady = true;
        }

        public void StartCompetition()
        {
            if (_competitionIsReady)
            {
                
            }
            else
            {
                // TODO: log
            }
        }

        public void EndCompetition()
        {
            _competitionIsReady = false;
        }

        public void VisualizeCompetitionResults()
        {
            
        }
    }
}
