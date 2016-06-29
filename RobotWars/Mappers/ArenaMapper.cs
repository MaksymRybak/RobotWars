using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models.Interfaces;
using RobotWars.DTO;

namespace RobotWars.Mappers
{
    public class ArenaMapper
    {
        private readonly IArenaFactory _arenaFactory;

        public ArenaMapper(IArenaFactory arenaFactory)
        {
            _arenaFactory = arenaFactory;
        }

        public IArenaCoordinates FromArenaCoordinatesDTOToArenaCoordinates(ArenaCoordinatesDTO arenaCoordinatesDTO)
        {
            IArenaCoordinates arenaCoordinates = null;

            if (arenaCoordinatesDTO != null)
            {
                arenaCoordinates = _arenaFactory.GetArenaCoordinates();
                int x = 0;
                if (int.TryParse(arenaCoordinatesDTO.X, out x))
                {
                    arenaCoordinates.X = x;
                }
                else
                {
                    // TODO: log
                }
            }

            return arenaCoordinates;
        }
    }
}
