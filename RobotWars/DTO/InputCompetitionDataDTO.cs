using System.Collections.Generic;

namespace RobotWars.DTO
{
    public class InputCompetitionDataDTO
    {
        public ArenaCoordinatesDTO ArenaBottomLeftCoords { get; set; }
        public ArenaCoordinatesDTO ArenaUpperRightCoords { get; set; }
        public List<InputRobotDTO> RobotsToDeploy { get; set; }

        public InputCompetitionDataDTO()
        {
            ArenaBottomLeftCoords = new ArenaCoordinatesDTO();
            ArenaUpperRightCoords = new ArenaCoordinatesDTO();
            RobotsToDeploy = new List<InputRobotDTO>();
        }
    }
}
