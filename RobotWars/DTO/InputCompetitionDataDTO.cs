using System.Collections.Generic;

namespace RobotWars.DTO
{
    public class InputCompetitionDataDTO
    {
        public InputArenaUpperRightCoordsDTO ArenaUpperRightCoords { get; set; }
        public List<InputRobotDTO> RobotsToDeploy { get; set; }

        public InputCompetitionDataDTO()
        {
            ArenaUpperRightCoords = new InputArenaUpperRightCoordsDTO();
            RobotsToDeploy = new List<InputRobotDTO>();
        }
    }
}
