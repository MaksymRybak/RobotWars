using System;

namespace RobotWars.DTO
{
    public class ArenaCoordinatesDTO
    {
        public string X { get; set; }
        public string Y { get; set; }

        public void TryParseInputCoords(string inputCoords)
        {
            try
            {
                var spaceDelimiterPos = inputCoords.IndexOf(" ");
                X = inputCoords.Substring(0, spaceDelimiterPos);
                Y = inputCoords.Substring(spaceDelimiterPos + 1, inputCoords.Length - X.Length - 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading input coordinates.", ex);
            }
        }
    }
}
