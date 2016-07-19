using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RobotWars.Core.Enums;
using RobotWars.Core.Factories.Interfaces;
using RobotWars.Core.Models;
using RobotWars.Core.Models.Interfaces;
using RobotWars.Core.System;
using RobotWars.Core.System.Logging;
using RobotWars.DTO;

namespace RobotWars.Tests
{
    [TestFixture]
    public class GameConsoleTests
    {
        private GameConsole gameConsole;
        private Mock<IBattleArena> battleArenaMock;
        private Mock<INavigationSystem> navigationSystemMock;
        private Mock<IConsoleWrapper> consoleMock;
        private Mock<IRobotFactory> robotFactoryMock;
        private Mock<IArenaFactory> arenaFactoryMock;
        private Mock<ILogWriter> logWriterMock;

        [SetUp]
        public void SetUp()
        {
            battleArenaMock = new Mock<IBattleArena>();
            navigationSystemMock = new Mock<INavigationSystem>();            
            consoleMock = new Mock<IConsoleWrapper>();
            robotFactoryMock = new Mock<IRobotFactory>();
            arenaFactoryMock = new Mock<IArenaFactory>();
            logWriterMock = new Mock<ILogWriter>();

            gameConsole = new GameConsole(battleArenaMock.Object, navigationSystemMock.Object, robotFactoryMock.Object, arenaFactoryMock.Object, consoleMock.Object, logWriterMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            gameConsole = null;
        }

        [Test]
        public void Should_setup_competition()
        {
            var competitionData = new InputCompetitionDataDTO
            {
                ArenaBottomLeftCoords = new ArenaCoordinatesDTO {X = "0", Y = "0"},
                ArenaUpperRightCoords = new ArenaCoordinatesDTO { X = "5", Y = "5" }
            };
            arenaFactoryMock.Setup(m => m.GetArenaCoordinates()).Returns(new ArenaCoordinates());

            gameConsole.SetUpCompetition(competitionData);

            battleArenaMock.Verify(a => a.SetUpArena(It.IsAny<IArenaCoordinates>(), It.IsAny<IArenaCoordinates>()), Times.Once);
            battleArenaMock.Verify(a => a.DeployRobots(It.IsAny<IList<IRobot>>()), Times.Once);
            navigationSystemMock.Verify(ns => ns.ConnectNavigationSystemToBattleArena(It.IsAny<IBattleArena>()), Times.Once);
        }

        [Test]
        public void Should_start_competition()
        {
            var competitionData = new InputCompetitionDataDTO
            {
                ArenaBottomLeftCoords = new ArenaCoordinatesDTO {X = "0", Y = "0"},
                ArenaUpperRightCoords = new ArenaCoordinatesDTO { X = "5", Y = "5" },
                RobotsToDeploy = new List<InputRobotDTO> { new InputRobotDTO
                {
                    Id = 1,
                    BattleMoves = new List<string>{"L", "M"},
                    StartHeadingDirection = "N",
                    StartLocation = new ArenaCoordinatesDTO {X = "1", Y = "2"}
                }}
            };

            robotFactoryMock.Setup(r => r.GetRobot()).Returns(new Robot(new Compass()){Position = new RobotPosition(), BattleMoves = new List<RobotMove>()});
            arenaFactoryMock.Setup(a => a.GetArenaCoordinates()).Returns(new ArenaCoordinates());

            gameConsole.SetUpCompetition(competitionData);
            gameConsole.StartCompetition();

            consoleMock.Verify(c => c.WriteLine(It.Is<string>(t => t.Equals(">>> Competition started"))), Times.Exactly(1));
            consoleMock.Verify(c => c.WriteLine(It.Is<string>(t => t.Equals(">>> Robot # {0} is moving")), It.Is<int>(id => id == 1)), Times.Exactly(1));
            navigationSystemMock.Verify(ns => ns.MoveRobot(It.Is<int>(id => id == 1), RobotMove.L), Times.Exactly(1));
            navigationSystemMock.Verify(ns => ns.MoveRobot(It.Is<int>(id => id == 1), RobotMove.M), Times.Exactly(1));
            consoleMock.Verify(c => c.WriteLine(It.Is<string>(t => t.Equals(">>> Robot # {0} finished")), It.Is<int>(id => id == 1)), Times.Exactly(1));
        }

        [Test]
        public void Should_end_competition()
        {
            gameConsole.EndCompetition();

            consoleMock.Verify(c => c.WriteLine(It.Is<string>(t => t.Equals(">>> Competition ended"))), Times.Exactly(1));
        }

        [Test]
        public void Should_visualize_competition_results()
        {
            gameConsole.VisualizeCompetitionResults();

            battleArenaMock.Verify(a => a.PrintRobotsPositions(), Times.Once);
        }
    }
}
