using System;

namespace RobotWars.Core.System
{
    public interface IConsoleWrapper
    {
        void Write(string value);
        void WriteLine(string value);
        void WriteLine(string value, object arg0);
        void WriteLine(string value, object arg0, object arg1);
        void WriteLine(string value, object arg0, object arg1, object arg2);
        void WriteLine(string value, object arg0, object arg1, object arg2, object arg3);
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

        public void WriteLine(string value, object arg0, object arg1)
        {
            Console.WriteLine(value, arg0, arg1);
        }

        public void WriteLine(string value, object arg0, object arg1, object arg2)
        {
            Console.WriteLine(value, arg0, arg1, arg2);
        }

        public void WriteLine(string value, object arg0, object arg1, object arg2, object arg3)
        {
            Console.WriteLine(value, arg0, arg1, arg2, arg3);
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

