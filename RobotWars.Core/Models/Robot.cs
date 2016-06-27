using System;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Models
{
    public class Robot : IRobot
    {
        public Guid Id { get; set; }
        public RobotPosition Position { get; set; }
    }
}
