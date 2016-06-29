using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RobotWars.Core.Enums;
using RobotWars.Core.Models;
using RobotWars.Core.Models.Interfaces;
using RobotWars.Core.System;
using SharpTestsEx;

namespace RobotWars.Core.Tests
{
    [TestFixture]
    public class BattleArenaTests
    {
        private IBattleArena battleArena;
        private Mock<IConsoleWrapper> consoleMock;

        [SetUp]
        public void SetUp()
        {
            consoleMock = new Mock<IConsoleWrapper>();
            battleArena = new BattleArena(consoleMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            battleArena = null;
        }

        [Test]
        public void Should_setup_arena()
        {
            battleArena.SetUpArena(null, null);
        }

        [Test]
        public void Should_deploy_robots()
        {
            var robotsToDeploy = new List<IRobot> {new Robot(new Compass())};
            battleArena.DeployRobots(robotsToDeploy);

            robotsToDeploy.ForEach(robot => robot.BattleArena.Should().Not.Be.Null());
        }

        [Test]
        public void Should_print_robots_positions()
        {
            var robotsToDeploy = new List<IRobot> { new Robot(new Compass()) {Position = new RobotPosition {Location = new ArenaCoordinates() {X = 1,Y = 2}, Heading = CompassPoint.N}} };
            battleArena.DeployRobots(robotsToDeploy);
            battleArena.PrintRobotsPositions();

            consoleMock.Verify(c => c.WriteLine(It.Is<string>(t => t.Equals(">>> Competition result"))), Times.Exactly(1));
            consoleMock.Verify(c => c.WriteLine(It.Is<string>(t => t.Equals(">>> Robots positions:"))), Times.Exactly(1));
            consoleMock.Verify(c => c.WriteLine(It.Is<string>(t => t.Equals(">>> Robot # {0}: {1} {2} {3}")),
                It.Is<int>(id => id == 0), It.Is<int>(x => x == 1), It.Is<int>(y => y == 2), It.Is<CompassPoint>(p => p == CompassPoint.N)), Times.Exactly(1));
        }

        [Test]
        public void Should_get_robot_by_id()
        {
            var robotsToDeploy = new List<IRobot> { new Robot(new Compass()) { Position = new RobotPosition { Location = new ArenaCoordinates() { X = 1, Y = 2 }, Heading = CompassPoint.N } } };
            battleArena.DeployRobots(robotsToDeploy);
            var robot = battleArena.GetRobotById(0);

            robot.Should().Not.Be.Null();
        }
    }
}
