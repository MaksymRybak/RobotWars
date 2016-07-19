using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars.DTO
{
    public class InputRobotDTO
    {
        public int Id { get; set; }
        public ArenaCoordinatesDTO StartLocation { get; set; }
        public string StartHeadingDirection { get; set; }

        public List<string> BattleMoves { get; set; }

        public InputRobotDTO()
        {
            StartLocation = new ArenaCoordinatesDTO();
            BattleMoves = new List<string>();
        }

        public void TryParseInputLocationAndHeadingDirection(string inputLocationAndHeading)
        {
            try
            {
                var spaceDelimiterPos = inputLocationAndHeading.IndexOf(" ", StringComparison.InvariantCultureIgnoreCase);
                StartLocation.X = inputLocationAndHeading.Substring(0, spaceDelimiterPos);
                var startYAndHeading = inputLocationAndHeading.Substring(spaceDelimiterPos + 1, inputLocationAndHeading.Length - StartLocation.X.Length - 1);
                var nextSpaceDelimiterPos = startYAndHeading.IndexOf(" ", StringComparison.InvariantCultureIgnoreCase);
                StartLocation.Y = startYAndHeading.Substring(0, nextSpaceDelimiterPos);
                StartHeadingDirection = startYAndHeading.Substring(nextSpaceDelimiterPos + 1, startYAndHeading.Length - StartLocation.Y.Length - 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading robot's position and orientation.", ex);
            }
        }

        public void TryParseInputBattleMoves(string inputBattleMoves)
        {
            try
            {
                inputBattleMoves.ToArray().ToList().ForEach(m => BattleMoves.Add(m.ToString()));
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading robot's battle moves. Please try again.", ex);
            }
        }
    }
}
