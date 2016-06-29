using Moq;
using NUnit.Framework;
using RobotWars.Core.Enums;
using RobotWars.Core.Models;
using RobotWars.Core.Models.Interfaces;

namespace RobotWars.Core.Tests
{
    public class NavigationSystemTests
    {
        private INavigationSystem navigationSystem;
        private Mock<IBattleArena> battleArenaMock;
        private Mock<IRobot> robotMock;

        [SetUp]
        public void SetUp()
        {
            navigationSystem = new NavigationSystem();
            battleArenaMock = new Mock<IBattleArena>();
            robotMock = new Mock<IRobot>();
        }

        [TearDown]
        public void TearDown()
        {
            navigationSystem = null;
        }

        [Test]
        public void Should_connect_navigation_system_to_battle_arena()
        {
            navigationSystem.ConnectNavigationSystemToBattleArena(battleArenaMock.Object);
        }

        [Test]
        public void Should_move_robot()
        {
            robotMock.Setup(r => r.PerformBattleMove(It.IsAny<RobotMove>()));
            battleArenaMock.Setup(a => a.GetRobotById(It.IsAny<int>())).Returns(robotMock.Object);

            navigationSystem.ConnectNavigationSystemToBattleArena(battleArenaMock.Object);
            navigationSystem.MoveRobot(1, RobotMove.L);
            robotMock.Verify(m => m.PerformBattleMove(It.IsAny<RobotMove>()), Times.Exactly(1));
        }
    }
}
