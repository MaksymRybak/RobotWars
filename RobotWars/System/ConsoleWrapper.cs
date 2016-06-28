using System;

namespace RobotWars.System
{
    public interface IConsoleWrapper
    {
        void Write(string value);
        void WriteLine(string value);
        void WriteLine(string value, object arg0);
        string ReadLine();
        string ReadArenaUpperRightCoords();
        string ReadRobotLocationAndHeadingDirection();
        string ReadRobotBattleMoves();
    }

    public class ConsoleWrapper : IConsoleWrapper
    {       
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string value, object arg0)
        {
            Console.WriteLine(value, arg0);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public string ReadArenaUpperRightCoords()
        {
            return Console.ReadLine();
        }

        public string ReadRobotLocationAndHeadingDirection()
        {
            return Console.ReadLine();
        }

        public string ReadRobotBattleMoves()
        {
            return Console.ReadLine();
        }
    }
}
