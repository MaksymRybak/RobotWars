using System;
using System.Collections.Generic;
using RobotWars.Core.Enums;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models.Interfaces;
using RobotWars.DTO;

namespace RobotWars.Mappers
{
    public class RobotMapper
    {
        private readonly IRobotFactory _robotFactory;
        private readonly IArenaFactory _arenaFactory;

        private readonly ArenaMapper _arenaMapper;

        public RobotMapper(IRobotFactory robotFactory, IArenaFactory arenaFactory)
        {
            _robotFactory = robotFactory;
            _arenaFactory = arenaFactory;

            _arenaMapper = new ArenaMapper(arenaFactory);
        }

        public IRobot FromRobotDTOToRobot(InputRobotDTO robotDTO)
        {
            IRobot robot = null;

            if (robotDTO != null)
            {
                robot = _robotFactory.GetRobot();
                robot.Id = robotDTO.Id;

                robot.Position.Location = _arenaMapper.FromArenaCoordinatesDTOToArenaCoordinates(robotDTO.StartLocation);
                CompassPoint hd;
                if (Enum.TryParse(robotDTO.StartHeadingDirection, out hd))
                {
                    robot.Position.Heading = hd;
                }
                else
                {
                    // TODO: log
                }

                if (robotDTO.BattleMoves != null && robotDTO.BattleMoves.Count > 0)
                {
                    robotDTO.BattleMoves.ForEach(move =>
                    {
                        RobotMove rm;
                        if (Enum.TryParse(move, out rm))
                        {
                            robot.BattleMoves.Add(rm);
                        }
                        else
                        {
                            // TODO: log
                        }
                    });
                }
            }

            return robot;
        }

        public IList<IRobot> FromListRobotDTOToListRobot(IList<InputRobotDTO> listRobotDTO)
        {
            IList<IRobot> listRobot = null;

            if (listRobotDTO != null && listRobotDTO.Count > 0)
            {
                listRobot = new List<IRobot>();
                foreach (var robotDTO in listRobotDTO)
                {
                    var robot = FromRobotDTOToRobot(robotDTO);
                    listRobot.Add(robot);
                }
            }

            return listRobot;
        }
    }
}
