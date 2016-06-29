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
    public class RobotTests
    {
        private IRobot robot;

        [SetUp]
        public void SetUp()
        {
            var consoleMock = new Mock<IConsoleWrapper>();

            robot = new Robot(new Compass());
            robot.Position = new RobotPosition {Location = new ArenaCoordinates { X = 1, Y = 2}, Heading = CompassPoint.N};
            robot.BattleArena = new BattleArena(consoleMock.Object) {BottomLeftCoordinates = new ArenaCoordinates {X = 0, Y=0}, UpperRightCoordinates = new ArenaCoordinates { X = 5, Y = 5}};
        }

        [TearDown]
        public void TearDown()
        {
            robot = null;
        }

        [Test]
        public void Should_perform_battle_move_spin_to_left()
        {
            robot.PerformBattleMove(RobotMove.L);
            robot.Position.Heading.Should().Be.EqualTo(CompassPoint.W);
            robot.Position.Location.X.Should().Be.EqualTo(1);
            robot.Position.Location.Y.Should().Be.EqualTo(2);
        }

        [Test]
        public void Should_perform_battle_move_spin_to_right()
        {
            robot.PerformBattleMove(RobotMove.R);
            robot.Position.Heading.Should().Be.EqualTo(CompassPoint.E);
            robot.Position.Location.X.Should().Be.EqualTo(1);
            robot.Position.Location.Y.Should().Be.EqualTo(2);
        }

        [Test]
        public void Should_perform_battle_move_forward_heading_north()
        {
            robot.PerformBattleMove(RobotMove.M);
            robot.Position.Heading.Should().Be.EqualTo(CompassPoint.N);
            robot.Position.Location.X.Should().Be.EqualTo(1);
            robot.Position.Location.Y.Should().Be.EqualTo(3);
        }

        [Test]
        public void Should_perform_battle_move_forward_heading_east()
        {
            robot.Position.Heading = CompassPoint.E;
            robot.PerformBattleMove(RobotMove.M);
            robot.Position.Heading.Should().Be.EqualTo(CompassPoint.E);
            robot.Position.Location.X.Should().Be.EqualTo(2);
            robot.Position.Location.Y.Should().Be.EqualTo(2);
        }

        [Test]
        public void Should_perform_battle_move_forward_heading_south()
        {
            robot.Position.Heading = CompassPoint.S;
            robot.PerformBattleMove(RobotMove.M);
            robot.Position.Heading.Should().Be.EqualTo(CompassPoint.S);
            robot.Position.Location.X.Should().Be.EqualTo(1);
            robot.Position.Location.Y.Should().Be.EqualTo(1);
        }

        [Test]
        public void Should_perform_battle_move_forward_heading_west()
        {
            robot.Position.Heading = CompassPoint.W;
            robot.PerformBattleMove(RobotMove.M);
            robot.Position.Heading.Should().Be.EqualTo(CompassPoint.W);
            robot.Position.Location.X.Should().Be.EqualTo(0);
            robot.Position.Location.Y.Should().Be.EqualTo(2);
        }

        [Test]
        public void Should_not_go_out_of_arena_left_border()
        {
            robot.Position.Heading = CompassPoint.W;
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.Position.Location.X.Should().Be.EqualTo(0);
        }

        [Test]
        public void Should_not_go_out_of_arena_bottom_border()
        {
            robot.Position.Heading = CompassPoint.S;
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.Position.Location.Y.Should().Be.EqualTo(0);
        }

        [Test]
        public void Should_not_go_out_of_arena_right_border()
        {
            robot.Position.Heading = CompassPoint.E;
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.Position.Location.X.Should().Be.EqualTo(robot.BattleArena.UpperRightCoordinates.X);
        }

        [Test]
        public void Should_not_go_out_of_arena_upper_border()
        {
            robot.Position.Heading = CompassPoint.N;
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.PerformBattleMove(RobotMove.M);
            robot.Position.Location.Y.Should().Be.EqualTo(robot.BattleArena.UpperRightCoordinates.Y);
        }
    }
}
